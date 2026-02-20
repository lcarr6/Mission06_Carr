using Microsoft.EntityFrameworkCore;

namespace Mission06_Carr.Models
{
    // Database context for Joel Hilton's movie collection
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}