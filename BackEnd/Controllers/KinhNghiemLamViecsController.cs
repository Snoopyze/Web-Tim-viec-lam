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
    public class KinhNghiemLamViecsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public KinhNghiemLamViecsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/KinhNghiemLamViecs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KinhNghiemLamViec>>> GetKinhNghiemLamViecs()
        {
            return await _context.KinhNghiemLamViecs.ToListAsync();
        }

        // GET: api/KinhNghiemLamViecs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KinhNghiemLamViec>> GetKinhNghiemLamViec(int id)
        {
            var kinhNghiemLamViec = await _context.KinhNghiemLamViecs.FindAsync(id);

            if (kinhNghiemLamViec == null)
            {
                return NotFound();
            }

            return kinhNghiemLamViec;
        }

        // PUT: api/KinhNghiemLamViecs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKinhNghiemLamViec(int id, KinhNghiemLamViec kinhNghiemLamViec)
        {
            if (id != kinhNghiemLamViec.IdKinhNghiemLamViec)
            {
                return BadRequest();
            }

            _context.Entry(kinhNghiemLamViec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KinhNghiemLamViecExists(id))
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

        // POST: api/KinhNghiemLamViecs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KinhNghiemLamViec>> PostKinhNghiemLamViec(KinhNghiemLamViec kinhNghiemLamViec)
        {
            _context.KinhNghiemLamViecs.Add(kinhNghiemLamViec);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KinhNghiemLamViecExists(kinhNghiemLamViec.IdKinhNghiemLamViec))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKinhNghiemLamViec", new { id = kinhNghiemLamViec.IdKinhNghiemLamViec }, kinhNghiemLamViec);
        }

        // DELETE: api/KinhNghiemLamViecs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKinhNghiemLamViec(int id)
        {
            var kinhNghiemLamViec = await _context.KinhNghiemLamViecs.FindAsync(id);
            if (kinhNghiemLamViec == null)
            {
                return NotFound();
            }

            _context.KinhNghiemLamViecs.Remove(kinhNghiemLamViec);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KinhNghiemLamViecExists(int id)
        {
            return _context.KinhNghiemLamViecs.Any(e => e.IdKinhNghiemLamViec == id);
        }
    }
}
