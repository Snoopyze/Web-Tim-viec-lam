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
    public class HoSoCvsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public HoSoCvsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/HoSoCvs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoSoCv>>> GetHoSoCvs()
        {
            return await _context.HoSoCvs.ToListAsync();
        }

        // GET: api/HoSoCvs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoSoCv>> GetHoSoCv(int id)
        {
            var hoSoCv = await _context.HoSoCvs.FindAsync(id);

            if (hoSoCv == null)
            {
                return NotFound();
            }

            return hoSoCv;
        }

        // PUT: api/HoSoCvs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoSoCv(int id, HoSoCv hoSoCv)
        {
            if (id != hoSoCv.IdCv)
            {
                return BadRequest();
            }

            _context.Entry(hoSoCv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoSoCvExists(id))
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

        // POST: api/HoSoCvs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoSoCv>> PostHoSoCv(HoSoCv hoSoCv)
        {
            _context.HoSoCvs.Add(hoSoCv);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HoSoCvExists(hoSoCv.IdCv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHoSoCv", new { id = hoSoCv.IdCv }, hoSoCv);
        }

        // DELETE: api/HoSoCvs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoSoCv(int id)
        {
            var hoSoCv = await _context.HoSoCvs.FindAsync(id);
            if (hoSoCv == null)
            {
                return NotFound();
            }

            _context.HoSoCvs.Remove(hoSoCv);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoSoCvExists(int id)
        {
            return _context.HoSoCvs.Any(e => e.IdCv == id);
        }

        // GET: api/HoSoCvs/5
        [HttpGet("{idUV}")]
        public async Task<ActionResult<HoSoCv>> GetHoSoCvByIDUngVien(int idUV)
        {
            var hoSoCv = await _context.HoSoCvs.FindAsync(idUV);

            if (hoSoCv == null)
            {
                return NotFound();
            }

            return hoSoCv;
        }
    }
}
