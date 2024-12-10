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
    public class TheoDoiCongTiesController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public TheoDoiCongTiesController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/TheoDoiCongTies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheoDoiCongTy>>> GetTheoDoiCongTies()
        {
            return await _context.TheoDoiCongTies.ToListAsync();
        }

        // GET: api/TheoDoiCongTies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TheoDoiCongTy>> GetTheoDoiCongTy(int id)
        {
            var theoDoiCongTy = await _context.TheoDoiCongTies.FindAsync(id);

            if (theoDoiCongTy == null)
            {
                return NotFound();
            }

            return theoDoiCongTy;
        }

        // PUT: api/TheoDoiCongTies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheoDoiCongTy(int id, TheoDoiCongTy theoDoiCongTy)
        {
            if (id != theoDoiCongTy.IdTheoDoiCongTy)
            {
                return BadRequest();
            }

            _context.Entry(theoDoiCongTy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheoDoiCongTyExists(id))
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

        // POST: api/TheoDoiCongTies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TheoDoiCongTy>> PostTheoDoiCongTy(TheoDoiCongTy theoDoiCongTy)
        {
            _context.TheoDoiCongTies.Add(theoDoiCongTy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TheoDoiCongTyExists(theoDoiCongTy.IdTheoDoiCongTy))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTheoDoiCongTy", new { id = theoDoiCongTy.IdTheoDoiCongTy }, theoDoiCongTy);
        }

        // DELETE: api/TheoDoiCongTies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheoDoiCongTy(int id)
        {
            var theoDoiCongTy = await _context.TheoDoiCongTies.FindAsync(id);
            if (theoDoiCongTy == null)
            {
                return NotFound();
            }

            _context.TheoDoiCongTies.Remove(theoDoiCongTy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheoDoiCongTyExists(int id)
        {
            return _context.TheoDoiCongTies.Any(e => e.IdTheoDoiCongTy == id);
        }
    }
}
