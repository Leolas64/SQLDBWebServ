using Microsoft.EntityFrameworkCore;

namespace API_WEB.Data
{

        public class DbContext_Concours : DbContext
        {
            public DbContext_Concours(DbContextOptions options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }
            public DbSet<Concours> Concoures { get; set; }
        }
    }

