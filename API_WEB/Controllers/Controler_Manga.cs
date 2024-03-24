using API_WEB.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using API_WEB.Classes;

namespace API_WEB.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Controler_Manga : ControllerBase
    {
            private readonly DBContext _context;

            public Controler_Manga(DBContext context)
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



        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<Manga>> PostManga(Manga manga)
        {
            _context.Mangas.Add(manga);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetManga), new { id = manga.Id }, manga);
        }


        [HttpPost]
        public async Task<ActionResult<Manga>> PostNewManga(Manga manga)
        {
            _context.Mangas.Add(manga);
            await _context.SaveChangesAsync();

            if(manga.idG == null)
            {

            }

            return CreatedAtAction(nameof(GetManga), new { id = manga.Id }, manga);
        }



        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManga(int id, Manga manga)
        {
            if (id != manga.Id)
            {
                return BadRequest();
            }

            _context.Entry(manga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManga(int id)
        {
            var manga = await _context.Mangas.FindAsync(id);
            if (manga == null)
            {
                return NotFound();
            }

            _context.Mangas.Remove(manga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Mangas.Any(e => e.Id == id);
        }

        // dummy method to test the connection
        [HttpGet("hello")]
        public string Test()
        {
            return "Hello World!";
        }

    } 
    }

