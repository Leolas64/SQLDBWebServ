using API_WEB.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;


namespace API_WEB.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class Controler_Concours : ControllerBase
        {
            private readonly DbContext_Concours _context;

            public Controler_Concours(DbContext_Concours context)
            {
                _context = context;
            }

            // GET: api/users
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Concours>>> GetConcours()
            {
                return await _context.Concoures.ToListAsync();
            }

            // GET: api/users/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Concours>> GetConcours(int id)
            {
                var concour = await _context.Concoures.FindAsync(id);

                if (concour == null)
                {
                    return NotFound();
                }

                return concour;

            }

            // POST: api/users
            [HttpPost]
            public async Task<ActionResult<Concours>> PostConcours(Concours concour)
            {
                _context.Concoures.Add(concour);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetConcours), new { id = concour.Id }, concour);
            }



            // PUT: api/users/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutConcours(int id, Concours concour)
            {
                if (id != concour.Id)
                {
                    return BadRequest();
                }

                _context.Entry(concour).State = EntityState.Modified;

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
            public async Task<IActionResult> DeleteConcours(int id)
            {
                var concour = await _context.Concoures.FindAsync(id);
                if (concour == null)
                {
                    return NotFound();
                }

                _context.Concoures.Remove(concour);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool UserExists(int id)
            {
                return _context.Concoures.Any(e => e.Id == id);
            }

            // dummy method to test the connection
            [HttpGet("hello")]
            public string Test()
            {
                return "Hello World!";
            }

        }
    }

