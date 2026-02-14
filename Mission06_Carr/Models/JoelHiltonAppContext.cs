using Microsoft.EntityFrameworkCore;

namespace Mission06_Carr.Models
{

    public class JoelHiltonAppContext : DbContext
    {
        public JoelHiltonAppContext(DbContextOptions<JoelHiltonAppContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}    