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
    public class NguoiGioiThieuxController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public NguoiGioiThieuxController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/NguoiGioiThieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiGioiThieu>>> GetNguoiGioiThieus()
        {
            return await _context.NguoiGioiThieus.ToListAsync();
        }

        // GET: api/NguoiGioiThieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiGioiThieu>> GetNguoiGioiThieu(int id)
        {
            var nguoiGioiThieu = await _context.NguoiGioiThieus.FindAsync(id);

            if (nguoiGioiThieu == null)
            {
                return NotFound();
            }

            return nguoiGioiThieu;
        }

        // PUT: api/NguoiGioiThieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiGioiThieu(int id, NguoiGioiThieu nguoiGioiThieu)
        {
            if (id != nguoiGioiThieu.IdNguoiGioiThieu)
            {
                return BadRequest();
            }

            _context.Entry(nguoiGioiThieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiGioiThieuExists(id))
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

        // POST: api/NguoiGioiThieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NguoiGioiThieu>> PostNguoiGioiThieu(NguoiGioiThieu nguoiGioiThieu)
        {
            _context.NguoiGioiThieus.Add(nguoiGioiThieu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguoiGioiThieuExists(nguoiGioiThieu.IdNguoiGioiThieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNguoiGioiThieu", new { id = nguoiGioiThieu.IdNguoiGioiThieu }, nguoiGioiThieu);
        }

        // DELETE: api/NguoiGioiThieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoiGioiThieu(int id)
        {
            var nguoiGioiThieu = await _context.NguoiGioiThieus.FindAsync(id);
            if (nguoiGioiThieu == null)
            {
                return NotFound();
            }

            _context.NguoiGioiThieus.Remove(nguoiGioiThieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoiGioiThieuExists(int id)
        {
            return _context.NguoiGioiThieus.Any(e => e.IdNguoiGioiThieu == id);
        }
    }
}
