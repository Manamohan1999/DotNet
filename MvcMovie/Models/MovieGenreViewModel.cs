using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string Moviegenre { get; set; }
        public string SearchString { get; set; }
        public Movie Movie { get; set; }
        public List<Genre> Genre { get; set; }
        public List<GenreView> GenreViews { get; set; }
    }
}
