using Microsoft.EntityFrameworkCore;
using API_WEB.Classes;

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

        public DbSet<Auteur> Auteurs { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Dessinateur> Dessinateurs { get; set; }

        public DbSet<Editeur> Editeurs { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Tome> Tomes { get; set; }

    }
}
