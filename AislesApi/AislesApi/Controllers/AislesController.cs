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
        [HttpPost("{id}/AddSection")]
        public async Task<ActionResult<Aisle>> AddSectionToAisle(int id, AisleSection newAisleSection)
        {
            if (id != newAisleSection.AisleId)
            {
                return BadRequest();
            }

            var existingAisle = _context.Aisles.Where(a => a.AisleId == id).Include(a => a.AisleSections).SingleOrDefault();


            //_context.Add(newAisleSection).State = EntityState.Modified;
            _context.Add<AisleSection>(newAisleSection);

            if (existingAisle != null)
            {
                existingAisle.AisleSections.Add(newAisleSection);
                await _context.SaveChangesAsync();
            } 
            else
            {

                return NotFound("Aisle ID is not available");

            }

            return existingAisle;
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
