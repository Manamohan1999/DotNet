using Microsoft.EntityFrameworkCore;

namespace RazorPages.Data
{
    public class RazorPagesMovieContext : DbContext {
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options) : base(options) {

        }

        public DbSet<RazorPages.Models.Movie> Movie {get; set;} 
    }
}