using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using API_Manga.Models;


namespace API_Manga.Data
{
    public class API_MangaContext : DbContext
    {
        public API_MangaContext(DbContextOptions<API_MangaContext> options) : base(options)
        {
        }


        public DbSet<Manga> Mangas { get; set; }
    }
}
