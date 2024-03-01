using API_WEB.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;

namespace API_WEB.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Controler_API : ControllerBase
    {
            private readonly API_MangaContext _context;

            public Controler_API(API_MangaContext context)
            {
                _context = context;
            }

            // GET: api/users
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Manga>>> GetMangas()
            {
                return await _context.Mangas.ToListAsync();
            }

            // GET: api/users/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Manga>> GetManga(int id)
            {
                var manga = await _context.Mangas.FindAsync(id);

                if (manga == null)
                {
                    return NotFound();
                }

                return manga;
            }
        } 
    }

