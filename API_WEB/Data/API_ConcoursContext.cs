using Microsoft.EntityFrameworkCore;

namespace API_WEB.Data
{
    public class API_ConcoursContext : DbContext_Concours
    {
        public API_ConcoursContext(DbContextOptions<API_ConcoursContext> options) : base(options)
        {
        }
        public DbSet<Concours> UsersConcours { get; set; }
    }
}
