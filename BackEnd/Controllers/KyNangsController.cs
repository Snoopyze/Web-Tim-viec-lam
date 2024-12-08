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
    public class KyNangsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public KyNangsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/KyNangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KyNang>>> GetKyNangs()
        {
            return await _context.KyNangs.ToListAsync();
        }

        // GET: api/KyNangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KyNang>> GetKyNang(int id)
        {
            var kyNang = await _context.KyNangs.FindAsync(id);

            if (kyNang == null)
            {
                return NotFound();
            }

            return kyNang;
        }

        // PUT: api/KyNangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKyNang(int id, KyNang kyNang)
        {
            if (id != kyNang.IdKyNang)
            {
                return BadRequest();
            }

            _context.Entry(kyNang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KyNangExists(id))
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

        // POST: api/KyNangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KyNang>> PostKyNang(KyNang kyNang)
        {
            _context.KyNangs.Add(kyNang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KyNangExists(kyNang.IdKyNang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKyNang", new { id = kyNang.IdKyNang }, kyNang);
        }

        // DELETE: api/KyNangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKyNang(int id)
        {
            var kyNang = await _context.KyNangs.FindAsync(id);
            if (kyNang == null)
            {
                return NotFound();
            }

            _context.KyNangs.Remove(kyNang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KyNangExists(int id)
        {
            return _context.KyNangs.Any(e => e.IdKyNang == id);
        }
    }
}
