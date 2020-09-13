using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AislesAPI.Models;

namespace AislesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AislesController : ControllerBase
    {
        private readonly AisleContext _context;

        public AislesController(AisleContext context)
        {
            _context = context;
        }

        // GET: api/Aisles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aisle>>> GetAisles()
        {
            return await _context.Aisles.ToListAsync();
        }

        // GET: api/Aisles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aisle>> GetAisle(int id)
        {
            var aisle = await _context.Aisles.FindAsync(id);

            if (aisle == null)
            {
                return NotFound();
            }

            return aisle;
        }

        // PUT: api/Aisles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAisle(int id, Aisle aisle)
        {
            if (id != aisle.AisleId)
            {
                return BadRequest();
            }

            _context.Entry(aisle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AisleExists(id))
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

        // POST: api/Aisles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Aisle>> PostAisle(Aisle aisle)
        {
            _context.Aisles.Add(aisle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAisle", new { id = aisle.AisleId }, aisle);
        }

        // DELETE: api/Aisles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aisle>> DeleteAisle(int id)
        {
            var aisle = await _context.Aisles.FindAsync(id);
            if (aisle == null)
            {
                return NotFound();
            }

            _context.Aisles.Remove(aisle);
            await _context.SaveChangesAsync();

            return aisle;
        }

        private bool AisleExists(int id)
        {
            return _context.Aisles.Any(e => e.AisleId == id);
        }
    }
}
