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

    }
}
