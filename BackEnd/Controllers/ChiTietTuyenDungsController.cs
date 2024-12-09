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
    public class ChiTietTuyenDungsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public ChiTietTuyenDungsController(DbQlcvContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetChiTietTuyenDungs()
        {
            var tuyenDungs = await (from ct in _context.ChiTietTuyenDungs
                                    join nt in _context.NhaTuyenDungs on ct.IdNhaTuyenDung equals nt.IdNhaTuyenDung
                                    join c in _context.CongTies on nt.IdCongTy equals c.IdCongTy
                                    select new
                                    {
                                        TieuDeTin = ct.TieuDeTin,
                                        TenCongTy = c.TenCongTy,
                                        LogoUrl = c.LogoUrl,
                                        HanUngTuyen = (ct.HanNopHoSo.ToDateTime(TimeOnly.MinValue) - DateTime.Now.Date).Days,
                                        mucLuongTu = ct.MucLuongTu,
                                        MucLuongToi = ct.MucLuongToi,
                                        DiaDiemLamViecCuThe = ct.DiaDiemLamViecCuThe
                                    }).ToListAsync();

            return Ok(tuyenDungs);
        }

        

        // GET: api/ChiTietTuyenDungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietTuyenDung>> GetChiTietTuyenDung(int id)
        {
            var chiTietTuyenDung = await _context.ChiTietTuyenDungs.FindAsync(id);

            if (chiTietTuyenDung == null)
            {
                return NotFound();
            }

            return chiTietTuyenDung;
        }

        // PUT: api/ChiTietTuyenDungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietTuyenDung(int id, ChiTietTuyenDung chiTietTuyenDung)
        {
            if (id != chiTietTuyenDung.IdChiTietTuyenDung)
            {
                return BadRequest();
            }

            _context.Entry(chiTietTuyenDung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietTuyenDungExists(id))
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

        // POST: api/ChiTietTuyenDungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietTuyenDung>> PostChiTietTuyenDung(ChiTietTuyenDung chiTietTuyenDung)
        {
            _context.ChiTietTuyenDungs.Add(chiTietTuyenDung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietTuyenDungExists(chiTietTuyenDung.IdChiTietTuyenDung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietTuyenDung", new { id = chiTietTuyenDung.IdChiTietTuyenDung }, chiTietTuyenDung);
        }

        // DELETE: api/ChiTietTuyenDungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietTuyenDung(int id)
        {
            var chiTietTuyenDung = await _context.ChiTietTuyenDungs.FindAsync(id);
            if (chiTietTuyenDung == null)
            {
                return NotFound();
            }

            _context.ChiTietTuyenDungs.Remove(chiTietTuyenDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietTuyenDungExists(int id)
        {
            return _context.ChiTietTuyenDungs.Any(e => e.IdChiTietTuyenDung == id);
        }
    }
}
