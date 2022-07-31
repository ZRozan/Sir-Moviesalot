using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesLibrary.DAL;
using MoviesLibrary.Models;
using MoviesLibrary.ViewModels;
using PagedList;

namespace MoviesLibrary.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Movie
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            // TODO: order by date created for default
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.ReleaseSort = sortOrder == "Release" ? "release_desc" : "Release";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var movies = from m in db.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.MovieTitle.Contains(searchString));
                // TODO: add directors to the search
            }

            switch (sortOrder)
            {
                case "title_desc":
                    movies = movies.OrderByDescending(m => m.MovieTitle);
                    break;
                case "Release":
                    movies = movies.OrderBy(m => m.ReleaseYear);
                    break;
                case "release_desc":
                    movies = movies.OrderByDescending(m => m.ReleaseYear);
                    break;
                default:
                    movies = movies.OrderBy(m => m.MovieTitle);
                    break;
            }

            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(movies.ToPagedList(pageNumber, pageSize));
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            var movie = new Movie();
            movie.Genres = new List<Genre>();
            PopulateSelectedGenres(movie);
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieTitle,ReleaseYear,Duration,Imdbscore,Metascore")] Movie movie, string[] selectedGenres)
        {
            try
            {
                if (selectedGenres != null)
                {
                    movie.Genres = new List<Genre>();
                    foreach(var genre in selectedGenres)
                    {
                        var genreToAdd = db.Genres.Find(int.Parse(genre));
                        movie.Genres.Add(genreToAdd);
                    }
                }
                if (ModelState.IsValid)
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to create a new register, try again.");
            }
            PopulateSelectedGenres(movie);
            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies
                .Include(m => m.Genres)
                .Where(m => m.Id == id)
                .Single();
            PopulateSelectedGenres(movie);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        private void PopulateSelectedGenres(Movie movie)
        {
            var allGenres = db.Genres;
            var movieGenres = new HashSet<int>(movie.Genres.Select(g => g.Id));
            var viewModel = new List<SelectedGenres>();
            foreach (var genre in allGenres)
            {
                viewModel.Add(new SelectedGenres
                {
                    GenresId = genre.Id,
                    GenreName = genre.GenreName,
                    IsSelected = movieGenres.Contains(genre.Id)
                });
            }
            ViewBag.Genres = viewModel;
        }


        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, string[] selectedGenres)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movieToUpdate = db.Movies
                .Include(m => m.Genres)
                .Where(m => m.Id == id)
                .Single();

            if (TryUpdateModel(movieToUpdate, "",
                new string[] { "Id", "MovieTitle", "ReleaseYear", "Duration", "Imdbscore", "Metascore" }))
            {
                try
                {
                    UpdateMovieGenres(selectedGenres, movieToUpdate);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again.");
                }
            }
            PopulateSelectedGenres(movieToUpdate);
            return View(movieToUpdate);
        }

        private void UpdateMovieGenres(string[] selectedGenres, Movie moviesToUpdate)
        {
            if (selectedGenres == null)
            {
                moviesToUpdate.Genres = new List<Genre>();
                return;
            }

            var selectedGenresHS = new HashSet<String>(selectedGenres);
            var movieGenres = new HashSet<int>
                (moviesToUpdate.Genres.Select(g => g.Id));

            foreach(var genre in db.Genres)
            {
                if (selectedGenres.Contains(genre.Id.ToString()))
                {
                    if (!movieGenres.Contains(genre.Id))
                    {
                        moviesToUpdate.Genres.Add(genre);
                    }
                }
                else
                {
                    if (movieGenres.Contains(genre.Id))
                    {
                        moviesToUpdate.Genres.Remove(genre);
                    }
                }
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try Again.";
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Movie movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
