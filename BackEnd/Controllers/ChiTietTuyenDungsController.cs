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

        // GET: api/ChiTietTuyenDungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietTuyenDung>>> GetChiTietTuyenDungs()
        {
            return await _context.ChiTietTuyenDungs.ToListAsync();
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

        [HttpGet("Diadiemlamviec{idCTDC}")]
        public async Task<IActionResult> getCongTyByIdNTD(int idCTDC)
        {

            DiaChiChiTiet dcct = await _context.DiaChiChiTiets
                               .FirstOrDefaultAsync(dc => dc.IdDiaChi == idCTDC);
            String dchi = "";
            if (dcct != null)
            {
                dchi += dcct.MoTaChiTiet;
                var phuongXa = await _context.PhuongXas
                   .FirstOrDefaultAsync(px => px.IdPhuongXa == dcct.IdPhuongXa);
                if (phuongXa != null)
                {
                    dchi += ", " + phuongXa.TenPhuongXa;
                    var quanHuyen = await _context.QuanHuyens
                        .FirstOrDefaultAsync(px => px.IdQuanHuyen == phuongXa.IdQuanHuyen);
                    if (quanHuyen != null)
                    {
                        dchi += ", " + quanHuyen.TenQuanHuyen;
                        var tinh = await _context.ThanhPhos
                        .FirstOrDefaultAsync(px => px.IdThanhPho == quanHuyen.IdThanhPho);
                        if (tinh != null)
                        {
                            dchi += ", " + tinh.TenThanhPho;
                            return Ok(dchi);
                        }
                        return Ok(dchi);
                    }
                    return Ok(dchi);
                }
                return Ok(dchi);

            }

            else
                return NotFound();
        }

    


    }
}
