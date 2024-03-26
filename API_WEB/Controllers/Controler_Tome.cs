using API_WEB.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using API_WEB.Classes;

namespace API_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controler_Tome : ControllerBase
    {
        private readonly DBContext _context;

        public Controler_Tome(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tome>>> GetTomes()
        {
            return await _context.Tomes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tome>> GetTome(int id)
        {
            var tome = await _context.Tomes.FindAsync(id);

            if (tome == null)
            {
                return NotFound();
            }

            return tome;

        }



        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<Manga>> PostTome(Tome tome)
        {
            _context.Tomes.Add(tome);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTome), new { id = tome.Id }, tome);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTome(int id, Tome tome)
        {
            if (id != tome.Id)
            {
                return BadRequest();
            }

            _context.Entry(tome).State = EntityState.Modified;

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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTome(int id)
        {
            var tome = await _context.Tomes.FindAsync(id);
            if (tome == null)
            {
                return NotFound();
            }

            _context.Tomes.Remove(tome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Tomes.Any(e => e.Id == id);
        }


    }
}
