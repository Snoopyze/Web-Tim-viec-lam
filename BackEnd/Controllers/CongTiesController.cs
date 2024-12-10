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
    public class CongTiesController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public CongTiesController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/CongTies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongTy>>> GetCongTies()
        {
            return await _context.CongTies.ToListAsync();
        }

        // GET: api/CongTies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CongTy>> GetCongTy(int id)
        {
            var congTy = await _context.CongTies.FindAsync(id);

            if (congTy == null)
            {
                return NotFound();
            }

            return congTy;
        }

        // PUT: api/CongTies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCongTy(int id, CongTy congTy)
        {
            if (id != congTy.IdCongTy)
            {
                return BadRequest();
            }

            _context.Entry(congTy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongTyExists(id))
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

        // POST: api/CongTies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CongTy>> PostCongTy(CongTy congTy)
        {
            _context.CongTies.Add(congTy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CongTyExists(congTy.IdCongTy))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCongTy", new { id = congTy.IdCongTy }, congTy);
        }

        // DELETE: api/CongTies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongTy(int id)
        {
            var congTy = await _context.CongTies.FindAsync(id);
            if (congTy == null)
            {
                return NotFound();
            }

            _context.CongTies.Remove(congTy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CongTyExists(int id)
        {
            return _context.CongTies.Any(e => e.IdCongTy == id);
        }
    }
}
