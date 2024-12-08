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
    public class NghesController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public NghesController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/Nghes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nghe>>> GetNghes()
        {
            return await _context.Nghes.ToListAsync();
        }

        // GET: api/Nghes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nghe>> GetNghe(int id)
        {
            var nghe = await _context.Nghes.FindAsync(id);

            if (nghe == null)
            {
                return NotFound();
            }

            return nghe;
        }

        // PUT: api/Nghes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNghe(int id, Nghe nghe)
        {
            if (id != nghe.IdNghe)
            {
                return BadRequest();
            }

            _context.Entry(nghe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NgheExists(id))
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

        // POST: api/Nghes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nghe>> PostNghe(Nghe nghe)
        {
            _context.Nghes.Add(nghe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NgheExists(nghe.IdNghe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNghe", new { id = nghe.IdNghe }, nghe);
        }

        // DELETE: api/Nghes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNghe(int id)
        {
            var nghe = await _context.Nghes.FindAsync(id);
            if (nghe == null)
            {
                return NotFound();
            }

            _context.Nghes.Remove(nghe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NgheExists(int id)
        {
            return _context.Nghes.Any(e => e.IdNghe == id);
        }
    }
}
