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
    public class ChungChisController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public ChungChisController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/ChungChis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChungChi>>> GetChungChis()
        {
            return await _context.ChungChis.ToListAsync();
        }

        // GET: api/ChungChis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChungChi>> GetChungChi(int id)
        {
            var chungChi = await _context.ChungChis.FindAsync(id);

            if (chungChi == null)
            {
                return NotFound();
            }

            return chungChi;
        }

        // PUT: api/ChungChis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChungChi(int id, ChungChi chungChi)
        {
            if (id != chungChi.IdChungChi)
            {
                return BadRequest();
            }

            _context.Entry(chungChi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChungChiExists(id))
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

        // POST: api/ChungChis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChungChi>> PostChungChi(ChungChi chungChi)
        {
            _context.ChungChis.Add(chungChi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChungChiExists(chungChi.IdChungChi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChungChi", new { id = chungChi.IdChungChi }, chungChi);
        }

        // DELETE: api/ChungChis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChungChi(int id)
        {
            var chungChi = await _context.ChungChis.FindAsync(id);
            if (chungChi == null)
            {
                return NotFound();
            }

            _context.ChungChis.Remove(chungChi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChungChiExists(int id)
        {
            return _context.ChungChis.Any(e => e.IdChungChi == id);
        }
    }
}
