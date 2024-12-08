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
    public class UngViensController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public UngViensController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/UngViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UngVien>>> GetUngViens()
        {
            return await _context.UngViens.ToListAsync();
        }

        // GET: api/UngViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UngVien>> GetUngVien(int id)
        {
            var ungVien = await _context.UngViens.FindAsync(id);

            if (ungVien == null)
            {
                return NotFound();
            }

            return ungVien;
        }

        // PUT: api/UngViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUngVien(int id, UngVien ungVien)
        {
            if (id != ungVien.IdUngVien)
            {
                return BadRequest();
            }

            _context.Entry(ungVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UngVienExists(id))
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

        // POST: api/UngViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UngVien>> PostUngVien(UngVien ungVien)
        {
            _context.UngViens.Add(ungVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UngVienExists(ungVien.IdUngVien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUngVien", new { id = ungVien.IdUngVien }, ungVien);
        }

        // DELETE: api/UngViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUngVien(int id)
        {
            var ungVien = await _context.UngViens.FindAsync(id);
            if (ungVien == null)
            {
                return NotFound();
            }

            _context.UngViens.Remove(ungVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UngVienExists(int id)
        {
            return _context.UngViens.Any(e => e.IdUngVien == id);
        }
    }
}
