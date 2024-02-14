using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Manga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly ILogger<MangaController> _logger;

        public MangaController(ILogger<MangaController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetManga")]
        //public IEnumerable<Manga> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new Manga
        //    {
        //        dateSortieProchainTome = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        nom = "Berserk",
        //        nbTomes = 42,
        //        etatAvancement = "Dernier tome sortie --> 41 + 41 collector"
        //    })
        //    .ToArray();
        //}


        [HttpGet(Name = "api-manga/v1/{manga}")]
        public IEnumerable<Manga> Get(int id, string nom, int tomes, string avancement)
        {
            Manga m1 = new Manga(1, "Berserk", 41, "Tome 42 en édition");
            Manga m2 = new Manga(2, "Fire Punch", 8, "Manga Terminé");
            Manga m3 = new Manga(id, nom, tomes, avancement);

            List<Manga> listManga = new List<Manga> { m1, m2, m3};

            return listManga;
        }

    }
}
