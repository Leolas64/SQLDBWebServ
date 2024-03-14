using Microsoft.EntityFrameworkCore;

namespace API_WEB.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Manga> Mangas { get; set; }

    }
}
