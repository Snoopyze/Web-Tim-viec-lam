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

        [HttpGet("UngVien/{idUV}")]
            public async Task<IActionResult> GetAllApplyJobs(int idUV)
            {
                var applyJobs = await _context.HoSoDaNops
                    .Where(l => l.IdUngVien == idUV)
                    .ToListAsync();
                var cv = await _context.HoSoCvs
                    .FirstOrDefaultAsync(c => c.IdUngVien == idUV); 
                if (!applyJobs.Any())
                {
                    return NotFound("Ứng viên chưa nộp tin tuyển dụng nào.");
                }

                var result = new List<object>();

                foreach (var job in applyJobs)
                {
                //chi tiêt tuyen dung
                    var jobDetail = await _context.ChiTietTuyenDungs
                        .FirstOrDefaultAsync(c => c.IdChiTietTuyenDung == job.IdChiTietTuyenDung);
                   

                if (jobDetail == null) continue;

                    var recruiter = await _context.NhaTuyenDungs
                        .FirstOrDefaultAsync(n => n.IdNhaTuyenDung == jobDetail.IdNhaTuyenDung);

                    if (recruiter == null) continue;

                    var company = await _context.CongTies
                        .FirstOrDefaultAsync(c => c.IdCongTy == recruiter.IdCongTy);

                    if (company == null) continue;

                // Thêm vào kết quả
                result.Add(new
                {
                    idChiTietTuyenDung = jobDetail.IdChiTietTuyenDung,
                    tieuDeTin = jobDetail.TieuDeTin,
                    tenCongTy = company.TenCongTy,
                    thoiGianNop = job.ThoiGianNop,
                    diaDiemLamViec = jobDetail.DiaDiemLamViecCuThe,
                    mucLuongTu = jobDetail.MucLuongTu,
                    mucLuongToi = jobDetail.MucLuongToi,
                    idCongTy = company.IdCongTy,
                    logoUrl = company.LogoUrl,
                    trangThai = job.TrangThai, 
                    cvUrl = cv.FileUrl
                });
                }

                return Ok(result);
            }

        }

    }
