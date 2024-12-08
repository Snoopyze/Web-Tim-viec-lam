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
    public class BaoCaoViPhamsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public BaoCaoViPhamsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/BaoCaoViPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaoCaoViPham>>> GetBaoCaoViPhams()
        {
            return await _context.BaoCaoViPhams.ToListAsync();
        }

        // GET: api/BaoCaoViPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaoCaoViPham>> GetBaoCaoViPham(int id)
        {
            var baoCaoViPham = await _context.BaoCaoViPhams.FindAsync(id);

            if (baoCaoViPham == null)
            {
                return NotFound();
            }

            return baoCaoViPham;
        }

        // PUT: api/BaoCaoViPhams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaoCaoViPham(int id, BaoCaoViPham baoCaoViPham)
        {
            if (id != baoCaoViPham.IdBaoCaoViPham)
            {
                return BadRequest();
            }

            _context.Entry(baoCaoViPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaoCaoViPhamExists(id))
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

        // POST: api/BaoCaoViPhams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaoCaoViPham>> PostBaoCaoViPham(BaoCaoViPham baoCaoViPham)
        {
            _context.BaoCaoViPhams.Add(baoCaoViPham);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BaoCaoViPhamExists(baoCaoViPham.IdBaoCaoViPham))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBaoCaoViPham", new { id = baoCaoViPham.IdBaoCaoViPham }, baoCaoViPham);
        }

        // DELETE: api/BaoCaoViPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaoCaoViPham(int id)
        {
            var baoCaoViPham = await _context.BaoCaoViPhams.FindAsync(id);
            if (baoCaoViPham == null)
            {
                return NotFound();
            }

            _context.BaoCaoViPhams.Remove(baoCaoViPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaoCaoViPhamExists(int id)
        {
            return _context.BaoCaoViPhams.Any(e => e.IdBaoCaoViPham == id);
        }
    }
}
