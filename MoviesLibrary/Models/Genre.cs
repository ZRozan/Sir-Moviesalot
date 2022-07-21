using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesLibrary.Models
{
    public enum GenreName
    {
        Action, Adventure, Animation, Biography, Comedy, Crime, Documentary, Drama, Family, Fantasy, 
        History, Horror, Music_Musical, Mystery, Romance, Sci_Fi, Sport, Thriller, War, Western
    }

    public class Genre
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public GenreName GenreName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}