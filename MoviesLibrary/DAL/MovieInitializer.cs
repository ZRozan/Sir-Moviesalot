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
                },
                new Movie
                {
                    MovieTitle="Inception",ReleaseYear=2014,Duration=169,Imdbscore=87,Metascore=74,
                    Description="A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                    Poster="https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UY209_CR0,0,140,209_AL_.jpg"
                },
                new Movie
                {
                    MovieTitle="Interstellar",ReleaseYear=2010,Duration=148,Imdbscore=88,Metascore=74,
                    Description="A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival",
                    Poster="https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UY209_CR0,0,140,209_AL_.jpg"
                }
            };
            movies.ForEach(movie => context.Movies.Add(movie));
            context.SaveChanges();

            var directors = new List<Director>
            {
                new Director { Name = "Kurt Wimmer", MovieId = 1 },
                new Director { Name = "Christopher Nolan", MovieId=2 },
                new Director { Name = "Christopher Nolan", MovieId=3 },
                new Director { Name = "Zekinha Snydero" }

            };
            directors.ForEach(director => context.Directors.Add(director));
            context.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre {MovieId = 1, GenreName=GenreName.Action},
                new Genre {MovieId = 1, GenreName=GenreName.Drama},
                new Genre {MovieId = 1, GenreName=GenreName.Sci_Fi},
                new Genre {MovieId = 1, GenreName=GenreName.Thriller},
                new Genre {MovieId = 2, GenreName=GenreName.Action},
                new Genre {MovieId = 2, GenreName=GenreName.Adventure},
                new Genre {MovieId = 2, GenreName=GenreName.Sci_Fi},
                new Genre {MovieId = 2, GenreName=GenreName.Thriller},
                new Genre {MovieId = 3, GenreName=GenreName.Adventure},
                new Genre {MovieId = 3, GenreName=GenreName.Drama},
                new Genre {MovieId = 3, GenreName=GenreName.Sci_Fi}
            };
            genres.ForEach(genre => context.Genres.Add(genre));
            context.SaveChanges();
        }

    }
}