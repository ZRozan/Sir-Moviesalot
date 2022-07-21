﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesLibrary.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}