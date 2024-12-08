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
    public class DiaChiChiTietsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public DiaChiChiTietsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/DiaChiChiTiets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChiChiTiet>>> GetDiaChiChiTiets()
        {
            return await _context.DiaChiChiTiets.ToListAsync();
        }

        // GET: api/DiaChiChiTiets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChiChiTiet>> GetDiaChiChiTiet(int id)
        {
            var diaChiChiTiet = await _context.DiaChiChiTiets.FindAsync(id);

            if (diaChiChiTiet == null)
            {
                return NotFound();
            }

            return diaChiChiTiet;
        }

        // PUT: api/DiaChiChiTiets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaChiChiTiet(int id, DiaChiChiTiet diaChiChiTiet)
        {
            if (id != diaChiChiTiet.IdDiaChi)
            {
                return BadRequest();
            }

            _context.Entry(diaChiChiTiet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaChiChiTietExists(id))
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

        // POST: api/DiaChiChiTiets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiaChiChiTiet>> PostDiaChiChiTiet(DiaChiChiTiet diaChiChiTiet)
        {
            _context.DiaChiChiTiets.Add(diaChiChiTiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DiaChiChiTietExists(diaChiChiTiet.IdDiaChi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiaChiChiTiet", new { id = diaChiChiTiet.IdDiaChi }, diaChiChiTiet);
        }

        // DELETE: api/DiaChiChiTiets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaChiChiTiet(int id)
        {
            var diaChiChiTiet = await _context.DiaChiChiTiets.FindAsync(id);
            if (diaChiChiTiet == null)
            {
                return NotFound();
            }

            _context.DiaChiChiTiets.Remove(diaChiChiTiet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiaChiChiTietExists(int id)
        {
            return _context.DiaChiChiTiets.Any(e => e.IdDiaChi == id);
        }
    }
}
