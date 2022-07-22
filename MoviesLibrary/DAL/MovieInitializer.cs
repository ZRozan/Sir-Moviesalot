using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MoviesLibrary.Models;

namespace MoviesLibrary.DAL
{
    public class MovieInitializer : DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    MovieTitle="Equilibrium",ReleaseYear=2002,Duration=107,Imdbscore=74,Metascore=33,
                    Description="In an oppressive future where all forms of feeling are illegal, a man in charge of enforcing the law rises to overthrow the system and state.",
                    Poster="https://m.media-amazon.com/images/M/MV5BMTkzMzA1OTI3N15BMl5BanBnXkFtZTYwMzUyMDg5._V1_UY209_CR0,0,140,209_AL_.jpg"
                }
            };
            movies.ForEach(movie => context.Movies.Add(movie));
            context.SaveChanges();

            var directors = new List<Director>
            {
                new Director { Name = "Kurt Wimmer", MovieId = 1 },
                new Director { Name = "Johnzinho" },
                new Director { Name = "Zekinha" }

            };
            directors.ForEach(director => context.Directors.Add(director));
            context.SaveChanges();

            //Action, Drama, Sci-Fi, Thriller

            var genres = new List<Genre>
            {
                new Genre {MovieId = 1, GenreName=GenreName.Action},
                new Genre {MovieId = 1, GenreName=GenreName.Drama},
                new Genre {MovieId = 1, GenreName=GenreName.Sci_Fi},
                new Genre {MovieId = 1, GenreName=GenreName.Thriller}
            };
            genres.ForEach(genre => context.Genres.Add(genre));
            context.SaveChanges();
        }

    }
}