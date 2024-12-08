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
    public class DanhHieuVaGiaiThuongsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public DanhHieuVaGiaiThuongsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/DanhHieuVaGiaiThuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhHieuVaGiaiThuong>>> GetDanhHieuVaGiaiThuongs()
        {
            return await _context.DanhHieuVaGiaiThuongs.ToListAsync();
        }

        // GET: api/DanhHieuVaGiaiThuongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhHieuVaGiaiThuong>> GetDanhHieuVaGiaiThuong(int id)
        {
            var danhHieuVaGiaiThuong = await _context.DanhHieuVaGiaiThuongs.FindAsync(id);

            if (danhHieuVaGiaiThuong == null)
            {
                return NotFound();
            }

            return danhHieuVaGiaiThuong;
        }

        // PUT: api/DanhHieuVaGiaiThuongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhHieuVaGiaiThuong(int id, DanhHieuVaGiaiThuong danhHieuVaGiaiThuong)
        {
            if (id != danhHieuVaGiaiThuong.IdDanhHieuVaGiaiThuong)
            {
                return BadRequest();
            }

            _context.Entry(danhHieuVaGiaiThuong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhHieuVaGiaiThuongExists(id))
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

        // POST: api/DanhHieuVaGiaiThuongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DanhHieuVaGiaiThuong>> PostDanhHieuVaGiaiThuong(DanhHieuVaGiaiThuong danhHieuVaGiaiThuong)
        {
            _context.DanhHieuVaGiaiThuongs.Add(danhHieuVaGiaiThuong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DanhHieuVaGiaiThuongExists(danhHieuVaGiaiThuong.IdDanhHieuVaGiaiThuong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDanhHieuVaGiaiThuong", new { id = danhHieuVaGiaiThuong.IdDanhHieuVaGiaiThuong }, danhHieuVaGiaiThuong);
        }

        // DELETE: api/DanhHieuVaGiaiThuongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhHieuVaGiaiThuong(int id)
        {
            var danhHieuVaGiaiThuong = await _context.DanhHieuVaGiaiThuongs.FindAsync(id);
            if (danhHieuVaGiaiThuong == null)
            {
                return NotFound();
            }

            _context.DanhHieuVaGiaiThuongs.Remove(danhHieuVaGiaiThuong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DanhHieuVaGiaiThuongExists(int id)
        {
            return _context.DanhHieuVaGiaiThuongs.Any(e => e.IdDanhHieuVaGiaiThuong == id);
        }
    }
}
