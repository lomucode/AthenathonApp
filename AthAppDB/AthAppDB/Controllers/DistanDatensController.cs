using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthAppDB.moduls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AthAppDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanDatensController : ControllerBase
    {
        private readonly ATHENATONContext _context;

        public DistanDatensController(ATHENATONContext context)
        {
            _context = context;
        }

        // GET: api/DistanDatens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistanDaten>>> GetDistanDatens()
        {
            return await _context.DistanDatens.ToListAsync();
        }

        // GET: api/DistanDatens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DistanDaten>> GetDistanDaten(int id)
        {
            var distanDaten = await _context.DistanDatens.FindAsync(id);

            if (distanDaten == null)
            {
                return NotFound();
            }

            return distanDaten;
        }

        // PUT: api/DistanDatens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistanDaten(int id, DistanDaten distanDaten)
        {
            if (id != distanDaten.Id)
            {
                return BadRequest();
            }

            _context.Entry(distanDaten).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistanDatenExists(id))
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

        // POST: api/DistanDatens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DistanDaten>> PostDistanDaten(DistanDaten distanDaten)
        {
            _context.DistanDatens.Add(distanDaten);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistanDaten", new { id = distanDaten.Id }, distanDaten);
        }

        // DELETE: api/DistanDatens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistanDaten(int id)
        {
            var distanDaten = await _context.DistanDatens.FindAsync(id);
            if (distanDaten == null)
            {
                return NotFound();
            }

            _context.DistanDatens.Remove(distanDaten);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistanDatenExists(int id)
        {
            return _context.DistanDatens.Any(e => e.Id == id);
        }
    }
}