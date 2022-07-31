using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MoviesLibrary.Models;

namespace MoviesLibrary.DAL
{
    public class MovieInitializer : DropCreateDatabaseIfModelChanges<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id=1, MovieTitle="Equilibrium",ReleaseYear=2002,Duration=107,Imdbscore=74,Metascore=33,
                    Description="In an oppressive future where all forms of feeling are illegal, a man in charge of enforcing the law rises to overthrow the system and state.",
                    Poster="https://m.media-amazon.com/images/M/MV5BMTkzMzA1OTI3N15BMl5BanBnXkFtZTYwMzUyMDg5._V1_UY209_CR0,0,140,209_AL_.jpg",
                    Genres = new List<Genre>()
                },
                new Movie
                {
                    Id=2, MovieTitle="Inception",ReleaseYear=2014,Duration=169,Imdbscore=87,Metascore=74,
                    Description="A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                    Poster="https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UY209_CR0,0,140,209_AL_.jpg",
                    Genres = new List<Genre>()
                },
                new Movie
                {
                    Id=3, MovieTitle="Interstellar",ReleaseYear=2010,Duration=148,Imdbscore=88,Metascore=74,
                    Description="A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival",
                    Poster="https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UY209_CR0,0,140,209_AL_.jpg",
                    Genres = new List<Genre>()
                }
            };
            movies.ForEach(movie => context.Movies.Add(movie));
            context.SaveChanges();

            var directors = new List<Director>
            {
                new Director { Name = "Kurt Wimmer", Biography = "lalala", Picture = "kakaka"},
                new Director { Name = "Christopher Nolan", Biography = "yada", Picture = "lada"},
                new Director { Name = "Zekinha Snydero", Biography = "jaja", Picture = "aoshdo"}

            };
            directors.ForEach(director => context.Directors.Add(director));
            context.SaveChanges();


            var genres = new List<Genre>
            {
                new Genre { GenreName= "Action"},
                new Genre { GenreName= "Adventure"},
                new Genre { GenreName= "Animation"},
                new Genre { GenreName= "Biography"},
                new Genre { GenreName= "Comedy"},
                new Genre { GenreName= "Crime"},
                new Genre { GenreName= "Documentary"},
                new Genre { GenreName= "Drama"},
                new Genre { GenreName= "Family"},
                new Genre { GenreName= "Fantasy"},
                new Genre { GenreName= "History"},
                new Genre { GenreName= "Horror"},
                new Genre { GenreName= "Music/Musical"},
                new Genre { GenreName= "Mystery"},
                new Genre { GenreName= "Romance"},
                new Genre { GenreName= "Sci-Fi"},
                new Genre { GenreName= "Sport"},
                new Genre { GenreName= "Thriller"},
                new Genre { GenreName= "War"},
                new Genre { GenreName= "Western"}
            };
            genres.ForEach(genre => context.Genres.Add(genre));
            context.SaveChanges();
        }
    }
}