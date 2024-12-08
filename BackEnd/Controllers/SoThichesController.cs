using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoThichesController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public SoThichesController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/SoThiches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoThich>>> GetSoThiches()
        {
            return await _context.SoThiches.ToListAsync();
        }

        // GET: api/SoThiches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoThich>> GetSoThich(int id)
        {
            var soThich = await _context.SoThiches.FindAsync(id);

            if (soThich == null)
            {
                return NotFound();
            }

            return soThich;
        }

        // PUT: api/SoThiches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoThich(int id, SoThich soThich)
        {
            if (id != soThich.IdSoThich)
            {
                return BadRequest();
            }

            _context.Entry(soThich).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoThichExists(id))
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

        // POST: api/SoThiches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoThich>> PostSoThich(SoThich soThich)
        {
            _context.SoThiches.Add(soThich);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SoThichExists(soThich.IdSoThich))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSoThich", new { id = soThich.IdSoThich }, soThich);
        }

        // DELETE: api/SoThiches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoThich(int id)
        {
            var soThich = await _context.SoThiches.FindAsync(id);
            if (soThich == null)
            {
                return NotFound();
            }

            _context.SoThiches.Remove(soThich);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoThichExists(int id)
        {
            return _context.SoThiches.Any(e => e.IdSoThich == id);
        }
    }
}
