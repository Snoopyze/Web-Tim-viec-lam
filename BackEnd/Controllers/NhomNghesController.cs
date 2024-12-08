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
    public class NhomNghesController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public NhomNghesController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/NhomNghes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhomNghe>>> GetNhomNghes()
        {
            return await _context.NhomNghes.ToListAsync();
        }

        // GET: api/NhomNghes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhomNghe>> GetNhomNghe(int id)
        {
            var nhomNghe = await _context.NhomNghes.FindAsync(id);

            if (nhomNghe == null)
            {
                return NotFound();
            }

            return nhomNghe;
        }

        // PUT: api/NhomNghes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhomNghe(int id, NhomNghe nhomNghe)
        {
            if (id != nhomNghe.IdNhomNghe)
            {
                return BadRequest();
            }

            _context.Entry(nhomNghe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhomNgheExists(id))
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

        // POST: api/NhomNghes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhomNghe>> PostNhomNghe(NhomNghe nhomNghe)
        {
            _context.NhomNghes.Add(nhomNghe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NhomNgheExists(nhomNghe.IdNhomNghe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNhomNghe", new { id = nhomNghe.IdNhomNghe }, nhomNghe);
        }

        // DELETE: api/NhomNghes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhomNghe(int id)
        {
            var nhomNghe = await _context.NhomNghes.FindAsync(id);
            if (nhomNghe == null)
            {
                return NotFound();
            }

            _context.NhomNghes.Remove(nhomNghe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhomNgheExists(int id)
        {
            return _context.NhomNghes.Any(e => e.IdNhomNghe == id);
        }
    }
}
