using Microsoft.EntityFrameworkCore;

namespace Mission06_Carr.Models
{

    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Category = "Action/Sci-Fi", Title = "Inception", Year = 2010, Director = "Christopher Nolan", Rating = "PG-13" },
                new Movie { MovieId = 2, Category = "Action/Sci-Fi", Title = "The Matrix", Year = 1999, Director = "The Wachowskis", Rating = "R" },
                new Movie { MovieId = 3, Category = "Sci-Fi", Title = "Interstellar", Year = 2014, Director = "Christopher Nolan", Rating = "PG-13" }
            );
        }
    }
}    