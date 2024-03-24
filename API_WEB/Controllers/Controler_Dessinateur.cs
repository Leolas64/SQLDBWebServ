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

    }
}
