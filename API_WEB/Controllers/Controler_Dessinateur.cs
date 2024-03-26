using API_WEB.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using API_WEB.Classes;

namespace API_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controler_Dessinateur : ControllerBase
    {

        private readonly DBContext _context;

        public Controler_Dessinateur(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dessinateur>>> GetDessinateurs()
        {
            return await _context.Dessinateurs.ToListAsync();
        }

        [HttpGet("{nom}")]
        public async Task<ActionResult<Dessinateur>> GetDessinateur(string nom)
        {
            var dessinateur = await _context.Dessinateurs.SingleAsync(x => x.nom == nom);
           // var dessinateurId = await _context.Dessinateurs.FindAsync(id);


            if (dessinateur == null)
            {
                return NotFound();
            }
            //else if (dessinateurId == null)
            //{
            //    return NotFound();
            //}

            return dessinateur;
        }

        [HttpPost]
        public async Task<ActionResult<Dessinateur>> PostDessinateur(Dessinateur dessinateur)
        {
            _context.Dessinateurs.Add(dessinateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDessinateur), new { nom = dessinateur.nom }, dessinateur);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDessinateur(int id, Dessinateur dessinateur)
        {
            if (id != dessinateur.Id)
            {
                return BadRequest();
            }

            _context.Entry(dessinateur).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteDessinateur(int id)
        {
            var dessinateur = await _context.Dessinateurs.FindAsync(id);
            if (dessinateur == null)
            {
                return NotFound();
            }

            _context.Dessinateurs.Remove(dessinateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Dessinateurs.Any(e => e.Id == id);
        }

    }
}
