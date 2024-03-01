using API_Manga.Data;
using API_Manga.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


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

        public class API : ControllerBase
        {
            private readonly API_MangaContext _apiMangaContext;

            public API(API_MangaContext context)
            {
                _apiMangaContext = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Manga>>> GetMangas()
            {
                return await _apiMangaContext.Mangas.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Manga>> GetMangas(int id)
            {
                var article = await _apiMangaContext.Mangas.FindAsync(id);

                if (article == null)
                {
                    return NotFound();
                }

                return article;
            }

            [HttpPost(Name = "PostUtilisateurV2")]
            public async Task<ActionResult<Manga>> PostMangas(Manga manga)
            {
                _apiMangaContext.Mangas.Add(manga);
                await _apiMangaContext.SaveChangesAsync();

                return CreatedAtAction("GetMangas", new { id = manga.Id }, manga);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutMangas(int id, Manga manga)
            {
                if (id != manga.Id)
                {
                    return BadRequest();
                }

                _apiMangaContext.Entry(manga).State = EntityState.Modified;
                try
                {
                    await _apiMangaContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MangaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteManga(int id)
            {
                var manga = await _apiMangaContext.Mangas.FindAsync(id);
                if (manga == null)
                {
                    return NotFound();
                }

                _apiMangaContext.Mangas.Remove(manga);
                await _apiMangaContext.SaveChangesAsync();

                return NoContent();
            }

            private bool MangaExists(int id)
            {
                return _apiMangaContext.Mangas.Any(e => e.Id == id);
            }
        }


    }
}
