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
    public class GopYsanPhamsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public GopYsanPhamsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/GopYsanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GopYsanPham>>> GetGopYsanPhams()
        {
            return await _context.GopYsanPhams.ToListAsync();
        }

        // GET: api/GopYsanPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GopYsanPham>> GetGopYsanPham(int id)
        {
            var gopYsanPham = await _context.GopYsanPhams.FindAsync(id);

            if (gopYsanPham == null)
            {
                return NotFound();
            }

            return gopYsanPham;
        }

        // PUT: api/GopYsanPhams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGopYsanPham(int id, GopYsanPham gopYsanPham)
        {
            if (id != gopYsanPham.IdGopYsanPham)
            {
                return BadRequest();
            }

            _context.Entry(gopYsanPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GopYsanPhamExists(id))
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

        // POST: api/GopYsanPhams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GopYsanPham>> PostGopYsanPham(GopYsanPham gopYsanPham)
        {
            _context.GopYsanPhams.Add(gopYsanPham);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GopYsanPhamExists(gopYsanPham.IdGopYsanPham))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGopYsanPham", new { id = gopYsanPham.IdGopYsanPham }, gopYsanPham);
        }

        // DELETE: api/GopYsanPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGopYsanPham(int id)
        {
            var gopYsanPham = await _context.GopYsanPhams.FindAsync(id);
            if (gopYsanPham == null)
            {
                return NotFound();
            }

            _context.GopYsanPhams.Remove(gopYsanPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GopYsanPhamExists(int id)
        {
            return _context.GopYsanPhams.Any(e => e.IdGopYsanPham == id);
        }
    }
}
