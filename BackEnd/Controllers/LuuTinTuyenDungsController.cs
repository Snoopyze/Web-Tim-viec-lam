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
    public class LuuTinTuyenDungsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public LuuTinTuyenDungsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/LuuTinTuyenDungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LuuTinTuyenDung>>> GetLuuTinTuyenDungs()
        {
            return await _context.LuuTinTuyenDungs.ToListAsync();
        }

        // GET: api/LuuTinTuyenDungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LuuTinTuyenDung>> GetLuuTinTuyenDung(int id)
        {
            var luuTinTuyenDung = await _context.LuuTinTuyenDungs.FindAsync(id);

            if (luuTinTuyenDung == null)
            {
                return NotFound();
            }

            return luuTinTuyenDung;
        }

        // PUT: api/LuuTinTuyenDungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLuuTinTuyenDung(int id, LuuTinTuyenDung luuTinTuyenDung)
        {
            if (id != luuTinTuyenDung.IdLuuTinTuyenDung)
            {
                return BadRequest();
            }

            _context.Entry(luuTinTuyenDung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LuuTinTuyenDungExists(id))
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

        // POST: api/LuuTinTuyenDungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LuuTinTuyenDung>> PostLuuTinTuyenDung(LuuTinTuyenDung luuTinTuyenDung)
        {
            _context.LuuTinTuyenDungs.Add(luuTinTuyenDung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LuuTinTuyenDungExists(luuTinTuyenDung.IdLuuTinTuyenDung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLuuTinTuyenDung", new { id = luuTinTuyenDung.IdLuuTinTuyenDung }, luuTinTuyenDung);
        }

        // DELETE: api/LuuTinTuyenDungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLuuTinTuyenDung(int id)
        {
            var luuTinTuyenDung = await _context.LuuTinTuyenDungs.FindAsync(id);
            if (luuTinTuyenDung == null)
            {
                return NotFound();
            }

            _context.LuuTinTuyenDungs.Remove(luuTinTuyenDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LuuTinTuyenDungExists(int id)
        {
            return _context.LuuTinTuyenDungs.Any(e => e.IdLuuTinTuyenDung == id);
        }
    }
}
