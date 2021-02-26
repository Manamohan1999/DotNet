using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorePagesMovie.Data;
using RazorePagesMovie.Models;

namespace RazorePagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorePagesMovie.Data.RazorePagesMovieContext _context;

        public IndexModel(RazorePagesMovie.Data.RazorePagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]
        public String SearchString { get; set; }
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet =true)]
        public String MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<String> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
