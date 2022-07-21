using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesLibrary.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public float Imdbscore { get; set; }
        public int Metascore { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }


        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
    }
}