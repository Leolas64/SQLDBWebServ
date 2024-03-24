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

    }
}
