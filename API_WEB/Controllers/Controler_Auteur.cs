using API_WEB.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using API_WEB.Classes;

namespace API_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controler_Auteur : ControllerBase
    {
        private readonly DBContext _context;

        public Controler_Auteur(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auteur>>> GetAuteur()
        {
            return await _context.Auteurs.ToListAsync();
        }

        [HttpGet("{nom}")]
        public async Task<ActionResult<Auteur>> GetAuteur(string nom)
        {
            var auteur = await _context.Auteurs.SingleAsync(x => x.nom == nom);

            if (auteur == null)
            {
                return NotFound();
            }

            return auteur;

        }

        [HttpPost]
        public async Task<ActionResult<Manga>> PostAuteur(Auteur auteur)
        {
            _context.Auteurs.Add(auteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuteur), new { nom = auteur.nom }, auteur);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuteur(int id, Auteur auteur)
        {
            if (id != auteur.Id)
            {
                return BadRequest();
            }

            _context.Entry(auteur).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteAuteur(int id)
        {
            var auteur = await _context.Auteurs.FindAsync(id);
            if (auteur == null)
            {
                return NotFound();
            }

            _context.Auteurs.Remove(auteur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Auteurs.Any(e => e.Id == id);
        }




    }
}
