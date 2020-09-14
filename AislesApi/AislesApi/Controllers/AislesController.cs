using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AislesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AislesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AislesController : ControllerBase
    {

        private AppDatabase _context;

        public AislesController(AppDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllAisles")]
        public async Task<ActionResult<IEnumerable<Aisle>>> GetAisles()
        {
            return await _context.Aisles.Include(a => a.Sections).ToListAsync();
        }

        [HttpGet]
        [Route("GetAisle/{id}")]
        public async Task<ActionResult<Aisle>> GetAisle(int id)
        {
            var aisle = await _context.Aisles.Include(a => a.Sections).FirstOrDefaultAsync(i => i.AisleID == id);

            if (aisle == null)
            {
                return NotFound();
            }

            return aisle;
        }

        [HttpPost]
        [Route("AddAisle")]
        public async Task<ActionResult<Aisle>> PostAisle(Aisle aisle)
        {
            _context.Aisles.Add(aisle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAisle", new { id = aisle.AisleID }, aisle);
        }

        [HttpPost]
        [Route("AddSectionTo/{id}")]
        public async Task<ActionResult<Aisle>> AddSectionToAisle(int id, Section newSection)
        {
            if (id != newSection.AisleID)
            {
                return BadRequest();
            }

            var existingAisle = _context.Aisles.Where(a => a.AisleID == id).Include(a => a.Sections).SingleOrDefault();


            //_context.Add(newAisleSection).State = EntityState.Modified;
            //_context.Add<Section>(newSection);

            if (existingAisle != null)
            {
                existingAisle.Sections.Add(newSection);
                await _context.SaveChangesAsync();
            }
            else
            {

                return NotFound("Aisle ID is not available");

            }

            return existingAisle;
        }

        [HttpDelete]
        [Route("DeleteAisle/{id}")]
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

        [HttpPut]
        [Route("ChangeAisleName/{id}")]
        public async Task<ActionResult<Aisle>> ChangeName(int id, Aisle aisle)
        {

            if (id != aisle.AisleID)
            {
                return BadRequest();
            }

            var existingAisle = _context.Aisles.Where(a => a.AisleID == aisle.AisleID).Include(a => a.Sections).SingleOrDefault();

            if (existingAisle != null)
            {
                _context.Entry(existingAisle).CurrentValues.SetValues(aisle);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return existingAisle;
        }




    }
}
