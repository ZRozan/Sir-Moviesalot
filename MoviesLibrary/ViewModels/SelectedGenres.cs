using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesLibrary.ViewModels
{
    // Instructor = movies
    public class SelectedGenres
    {
        public int GenresId { get; set; }
        public string GenreName { get; set; }
        public bool IsSelected { get; set; }
    }
}