using Microsoft.EntityFrameworkCore;

namespace API_WEB.Data
{
    public class API_MangaContext : DBContext
    {

            public API_MangaContext(DbContextOptions<API_MangaContext> options) : base(options)
            {
            }
            public DbSet<Manga> Users { get; set; }

    }
}
