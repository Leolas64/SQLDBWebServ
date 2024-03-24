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
    }
}
