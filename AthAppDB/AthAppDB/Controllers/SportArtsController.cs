using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthAppDB.moduls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AthAppDB.Controllers.Services

{
    [Route("api/[controller]")]
    [ApiController]
    public class SportArtsController : ControllerBase
    {
        private readonly ATHENATONContext _context;

        public SportArtsController(ATHENATONContext context)
        {
            _context = context;
        }

        // GET: api/SportArts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportArt>>> GetSportArts()
        {
            return await _context.SportArts.ToListAsync();
        }

        // GET: api/SportArts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportArt>> GetSportArt(int id)
        {
            var sportArt = await _context.SportArts.FindAsync(id);

            if (sportArt == null)
            {
                return NotFound();
            }

            return sportArt;
        }

        // PUT: api/SportArts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportArt(int id, SportArt sportArt)
        {
            if (id != sportArt.Id)
            {
                return BadRequest();
            }

            _context.Entry(sportArt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportArtExists(id))
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

        // POST: api/SportArts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SportArt>> PostSportArt(SportArt sportArt)
        {
            _context.SportArts.Add(sportArt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSportArt", new { id = sportArt.Id }, sportArt);
        }

        // DELETE: api/SportArts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportArt(int id)
        {
            var sportArt = await _context.SportArts.FindAsync(id);
            if (sportArt == null)
            {
                return NotFound();
            }

            _context.SportArts.Remove(sportArt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportArtExists(int id)
        {
            return _context.SportArts.Any(e => e.Id == id);
        }
    }
}

