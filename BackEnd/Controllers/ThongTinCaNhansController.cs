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
    public class ThongTinCaNhansController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public ThongTinCaNhansController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/ThongTinCaNhans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTinCaNhan>>> GetThongTinCaNhans()
        {
            return await _context.ThongTinCaNhans.ToListAsync();
        }

        // GET: api/ThongTinCaNhans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThongTinCaNhan>> GetThongTinCaNhan(int id)
        {
            var thongTinCaNhan = await _context.ThongTinCaNhans.FindAsync(id);

            if (thongTinCaNhan == null)
            {
                return NotFound();
            }

            return thongTinCaNhan;
        }

        // PUT: api/ThongTinCaNhans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThongTinCaNhan(int id, ThongTinCaNhan thongTinCaNhan)
        {
            if (id != thongTinCaNhan.IdThongTinCaNhan)
            {
                return BadRequest();
            }

            _context.Entry(thongTinCaNhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThongTinCaNhanExists(id))
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

        // POST: api/ThongTinCaNhans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThongTinCaNhan>> PostThongTinCaNhan(ThongTinCaNhan thongTinCaNhan)
        {
            _context.ThongTinCaNhans.Add(thongTinCaNhan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThongTinCaNhanExists(thongTinCaNhan.IdThongTinCaNhan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThongTinCaNhan", new { id = thongTinCaNhan.IdThongTinCaNhan }, thongTinCaNhan);
        }

        // DELETE: api/ThongTinCaNhans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThongTinCaNhan(int id)
        {
            var thongTinCaNhan = await _context.ThongTinCaNhans.FindAsync(id);
            if (thongTinCaNhan == null)
            {
                return NotFound();
            }

            _context.ThongTinCaNhans.Remove(thongTinCaNhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThongTinCaNhanExists(int id)
        {
            return _context.ThongTinCaNhans.Any(e => e.IdThongTinCaNhan == id);
        }
    }
}
