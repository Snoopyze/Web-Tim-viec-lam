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
    public class ThanhPhoesController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public ThanhPhoesController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/ThanhPhoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThanhPho>>> GetThanhPhos()
        {
            return await _context.ThanhPhos.ToListAsync();
        }

        // GET: api/ThanhPhoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThanhPho>> GetThanhPho(int id)
        {
            var thanhPho = await _context.ThanhPhos.FindAsync(id);

            if (thanhPho == null)
            {
                return NotFound();
            }

            return thanhPho;
        }

        // PUT: api/ThanhPhoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThanhPho(int id, ThanhPho thanhPho)
        {
            if (id != thanhPho.IdThanhPho)
            {
                return BadRequest();
            }

            _context.Entry(thanhPho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanhPhoExists(id))
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

        // POST: api/ThanhPhoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThanhPho>> PostThanhPho(ThanhPho thanhPho)
        {
            _context.ThanhPhos.Add(thanhPho);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThanhPhoExists(thanhPho.IdThanhPho))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThanhPho", new { id = thanhPho.IdThanhPho }, thanhPho);
        }

        // DELETE: api/ThanhPhoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThanhPho(int id)
        {
            var thanhPho = await _context.ThanhPhos.FindAsync(id);
            if (thanhPho == null)
            {
                return NotFound();
            }

            _context.ThanhPhos.Remove(thanhPho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThanhPhoExists(int id)
        {
            return _context.ThanhPhos.Any(e => e.IdThanhPho == id);
        }
    }
}
