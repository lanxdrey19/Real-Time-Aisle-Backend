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
            var aisle = await _context.Aisles.Include(a => a.Sections).SingleOrDefaultAsync(i => i.AisleID == id);

            if (aisle == null)
            {
                return NotFound();
            }

            return aisle;
        }

        [HttpGet]
        [Route("GetAisleByName/{name}")]
        public async Task<ActionResult<Aisle>> GetAisleByBame(string name)
        {
            var aisle = await _context.Aisles.Include(a => a.Sections).FirstOrDefaultAsync(i => i.AisleName == name);

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
        [Route("ChangeAisleDetails/{id}")]
        public async Task<ActionResult<Aisle>> ChangeName(int id, Aisle aisle)
        {

            if (id != aisle.AisleID)
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

            return aisle;
        }

        private bool AisleExists(int id)
        {
            return _context.Aisles.Any(e => e.AisleID == id);
        }



    }
}
