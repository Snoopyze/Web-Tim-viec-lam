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
    public class ViTriChuyenMonsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public ViTriChuyenMonsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/ViTriChuyenMons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViTriChuyenMon>>> GetViTriChuyenMons()
        {
            return await _context.ViTriChuyenMons.ToListAsync();
        }

        // GET: api/ViTriChuyenMons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViTriChuyenMon>> GetViTriChuyenMon(int id)
        {
            var viTriChuyenMon = await _context.ViTriChuyenMons.FindAsync(id);

            if (viTriChuyenMon == null)
            {
                return NotFound();
            }

            return viTriChuyenMon;
        }

        // PUT: api/ViTriChuyenMons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViTriChuyenMon(int id, ViTriChuyenMon viTriChuyenMon)
        {
            if (id != viTriChuyenMon.IdViTriChuyenMon)
            {
                return BadRequest();
            }

            _context.Entry(viTriChuyenMon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViTriChuyenMonExists(id))
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

        // POST: api/ViTriChuyenMons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViTriChuyenMon>> PostViTriChuyenMon(ViTriChuyenMon viTriChuyenMon)
        {
            _context.ViTriChuyenMons.Add(viTriChuyenMon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ViTriChuyenMonExists(viTriChuyenMon.IdViTriChuyenMon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetViTriChuyenMon", new { id = viTriChuyenMon.IdViTriChuyenMon }, viTriChuyenMon);
        }

        // DELETE: api/ViTriChuyenMons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViTriChuyenMon(int id)
        {
            var viTriChuyenMon = await _context.ViTriChuyenMons.FindAsync(id);
            if (viTriChuyenMon == null)
            {
                return NotFound();
            }

            _context.ViTriChuyenMons.Remove(viTriChuyenMon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViTriChuyenMonExists(int id)
        {
            return _context.ViTriChuyenMons.Any(e => e.IdViTriChuyenMon == id);
        }
    }
}
