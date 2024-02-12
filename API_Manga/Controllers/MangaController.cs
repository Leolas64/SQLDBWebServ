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

        [HttpGet(Name = "GetManga")]
        public IEnumerable<Manga> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Manga
            {
                dateSortieProchainTome = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                nom = "Berserk",
                nbTomes = 42,
                etatAvancement = "Dernier tome sortie --> 41 + 41 collector"
            })
            .ToArray();
        }
    }
}
