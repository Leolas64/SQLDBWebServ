using Microsoft.AspNetCore.Mvc;
using API_WEB.Data;
using System;
using Microsoft.EntityFrameworkCore;
using API_WEB.Classes;
namespace API_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controler_Editeur : ControllerBase
    {
        private readonly DBContext _context;

        public Controler_Editeur(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editeur>>> GetEditeurs()
        {
            return await _context.Editeurs.ToListAsync();
        }


        [HttpGet("{nom}")]
        public async Task<ActionResult<Editeur>> GetEditeur(string nom)
        {
            var editeur = await _context.Editeurs.SingleAsync(x => x.nom == nom);

            if (editeur == null)
            {
                return NotFound();
            }

            return editeur;

        }


        [HttpPost]
        public async Task<ActionResult<Manga>> PostEditeur(Editeur editeur)
        {
            _context.Editeurs.Add(editeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEditeur), new { nom = editeur.nom }, editeur);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditeur(int id, Editeur editeur)
        {
            if (id != editeur.Id)
            {
                return BadRequest();
            }

            _context.Entry(editeur).State = EntityState.Modified;

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
            var editeur = await _context.Editeurs.FindAsync(id);
            if (editeur == null)
            {
                return NotFound();
            }

            _context.Editeurs.Remove(editeur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Editeurs.Any(e => e.Id == id);
        }



    }
}
