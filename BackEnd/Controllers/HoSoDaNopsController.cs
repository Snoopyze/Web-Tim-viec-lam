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
    public class HoSoDaNopsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public HoSoDaNopsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/HoSoDaNops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoSoDaNop>>> GetHoSoDaNops()
        {
            return await _context.HoSoDaNops.ToListAsync();
        }

        // GET: api/HoSoDaNops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoSoDaNop>> GetHoSoDaNop(int id)
        {
            var hoSoDaNop = await _context.HoSoDaNops.FindAsync(id);

            if (hoSoDaNop == null)
            {
                return NotFound();
            }

            return hoSoDaNop;
        }

        // PUT: api/HoSoDaNops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoSoDaNop(int id, HoSoDaNop hoSoDaNop)
        {
            if (id != hoSoDaNop.IdHoSoDaNop)
            {
                return BadRequest();
            }

            _context.Entry(hoSoDaNop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoSoDaNopExists(id))
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

        // POST: api/HoSoDaNops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoSoDaNop>> PostHoSoDaNop(HoSoDaNop hoSoDaNop)
        {
            _context.HoSoDaNops.Add(hoSoDaNop);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HoSoDaNopExists(hoSoDaNop.IdHoSoDaNop))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHoSoDaNop", new { id = hoSoDaNop.IdHoSoDaNop }, hoSoDaNop);
        }

        // DELETE: api/HoSoDaNops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoSoDaNop(int id)
        {
            var hoSoDaNop = await _context.HoSoDaNops.FindAsync(id);
            if (hoSoDaNop == null)
            {
                return NotFound();
            }

            _context.HoSoDaNops.Remove(hoSoDaNop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoSoDaNopExists(int id)
        {
            return _context.HoSoDaNops.Any(e => e.IdHoSoDaNop == id);
        }

        //Update trạng thái cv
        [HttpPost("UpdateTrangThai")]
        public async Task<IActionResult> UpdateTrangThai(int idHoSo, string trangThai)
        {
            try
            {
                var hoSo = await _context.HoSoDaNops.FirstOrDefaultAsync(h => h.IdHoSoDaNop == idHoSo);
                if (hoSo == null)
                {
                    return NotFound(new { Success = false, Message = "Không tìm thấy hồ sơ." });
                }

             
                hoSo.TrangThai = trangThai;
                await _context.SaveChangesAsync();

                return Ok(new { Success = true, Message = "Cập nhật trạng thái thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = $"Lỗi server: {ex.Message}" });
            }
        }

        // DemCVUngTuyenMoi
        [HttpGet("DemCVUngTuyenMoi")]
        public IActionResult GetPendingCVCount()
        {
            int pendingCVCount = _context.HoSoDaNops.Count(cv => cv.TrangThai == "Chờ duyệt");
            return Ok(new { PendingCVCount = pendingCVCount });
        }

        // DemCVDaTiepNhan
        [HttpGet("DemCVDaTiepNhan")]
        public IActionResult GetApprovedCVCount()
        {
            int approvedCVCount = _context.HoSoDaNops.Count(cv => cv.TrangThai == "Đã duyệt");
            return Ok(new { ApprovedCVCount = approvedCVCount });
        }
    }
}
