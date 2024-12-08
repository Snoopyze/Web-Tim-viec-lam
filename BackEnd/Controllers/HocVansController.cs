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
    public class HocVansController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public HocVansController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/HocVans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HocVan>>> GetHocVans()
        {
            return await _context.HocVans.ToListAsync();
        }

        // GET: api/HocVans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HocVan>> GetHocVan(int id)
        {
            var hocVan = await _context.HocVans.FindAsync(id);

            if (hocVan == null)
            {
                return NotFound();
            }

            return hocVan;
        }

        // PUT: api/HocVans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocVan(int id, HocVan hocVan)
        {
            if (id != hocVan.IdHocVan)
            {
                return BadRequest();
            }

            _context.Entry(hocVan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocVanExists(id))
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

        // POST: api/HocVans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HocVan>> PostHocVan(HocVan hocVan)
        {
            _context.HocVans.Add(hocVan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HocVanExists(hocVan.IdHocVan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHocVan", new { id = hocVan.IdHocVan }, hocVan);
        }

        // DELETE: api/HocVans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocVan(int id)
        {
            var hocVan = await _context.HocVans.FindAsync(id);
            if (hocVan == null)
            {
                return NotFound();
            }

            _context.HocVans.Remove(hocVan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocVanExists(int id)
        {
            return _context.HocVans.Any(e => e.IdHocVan == id);
        }
    }
}
