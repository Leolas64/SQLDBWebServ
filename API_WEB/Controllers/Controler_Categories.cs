using API_WEB.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using API_WEB.Classes;

namespace API_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controler_Categories : ControllerBase
    {
        private readonly DBContext _context;

        public Controler_Categories(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpGet("{nom}")]
        public async Task<ActionResult<Categorie>> GetCategorie(string nom)
        {
            var categorie = await _context.Categories.SingleAsync(x => x.nom == nom);

            if (categorie == null)
            {
                return NotFound();
            }

            return categorie;

        }
    }
}
