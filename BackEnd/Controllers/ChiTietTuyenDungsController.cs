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

       



        // POST: api/ChiTietTuyenDungs/AddContent
        // POST: api/ChiTietTuyenDungs/AddContent
        [HttpPost("AddContent")]
        public async Task<ActionResult<ChiTietTuyenDung>> AddContent(AddContentRequest request)
        {





            // Generate a random ID and add the offset 16052005
            var random = new Random();
            int generatedId = random.Next(1, 1000000) + 16052004;

            //// Ensure the generated ID is unique
            while (ChiTietTuyenDungExists(generatedId))
            {
                generatedId = random.Next(1, 1000000) + 16052004;
            }

            //// Override IdChiTietTuyenDungs in request with the generated value
            request.IdChiTietTuyenDungs = generatedId;

            // Map AddContentRequest to ChiTietTuyenDung
            var chiTietTuyenDung = new ChiTietTuyenDung
            {
                IdChiTietTuyenDung = request.IdChiTietTuyenDungs, // Use updated IdChiTietTuyenDungs
                TieuDeTin = request.TieuDeTins,
                KinhNghiem = request.KinhNghiems,
                MoTaCongViec = request.MoTaCongViecs,
                YeuCauUngVien = request.YeuCauUngViens,
                QuyenLoiUngVien = request.QuyenLoiUngViens,
                CachThucUngTuyen = request.CachThucUngTuyens,
                LoaiCongViec = request.LoaiCongViecs,
                MucLuongTu = request.MucLuongTus,
                MucLuongToi = request.MucLuongTois,
                LoaiTienTe = request.LoaiTienTes,
                HanNopHoSo = request.HanNopHoSos,
                SoLuongUngTuyen = request.SoLuongUngTuyens,
                DiaDiemLamViecCuThe = request.DiaDiemLamViecCuThes,
                GioiTinh = request.GioiTinhs,
                ThoiGianLamViecTuThu = request.ThoiGianLamViecTuThus,
                ThoiGianLamViecDenThu = request.ThoiGianLamViecDenThus,
                ThoiGianLamViecTuGio = request.ThoiGianLamViecTuGios,
                ThoiGianLamViecDenGio = request.ThoiGianLamViecDenGios,
                HoTenNguoiNhan = request.HoTenNguoiNhans,
                SoDienThoaiNguoiNhan = request.SoDienThoaiNguoiNhans,
                EmailNguoiNhan = request.EmailNguoiNhans,
                IdNhaTuyenDung = request.IdNhaTuyenDungs,
                ViTriChuyenMon = request.ViTriChuyenMons,
                ChiTietDiaDiemLamViec = request.ChiTietDiaDiemLamViecs
            };

            // Add the new object to the database
            _context.ChiTietTuyenDungs.Add(chiTietTuyenDung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict("Có lỗi xảy ra khi lưu dữ liệu.");
            }

            // Return the created object
            return CreatedAtAction(nameof(GetChiTietTuyenDung), new { id = chiTietTuyenDung.IdChiTietTuyenDung }, chiTietTuyenDung);
        }

        // Helper method to check if a ChiTietTuyenDung exists
       

        private bool ChiTietTuyenDungExists(int id)
        {
            return _context.ChiTietTuyenDungs.Any(e => e.IdChiTietTuyenDung == id);
        }

        public class AddContentRequest
        {
            public int IdChiTietTuyenDungs { get; set; }

            public string TieuDeTins { get; set; } = null!;

            public string KinhNghiems { get; set; } = null!;

            public string MoTaCongViecs { get; set; } = null!;

            public string YeuCauUngViens { get; set; } = null!;

            public string QuyenLoiUngViens { get; set; } = null!;

            public string CachThucUngTuyens { get; set; } = null!;

            public string LoaiCongViecs { get; set; } = null!;

            public string MucLuongTus { get; set; } = null!;

            public string MucLuongTois { get; set; } = null!;

            public string LoaiTienTes { get; set; } = null!;

            public DateOnly HanNopHoSos { get; set; }

            public string SoLuongUngTuyens { get; set; } = null!;

            public string DiaDiemLamViecCuThes { get; set; } = null!;

            public string GioiTinhs { get; set; } = null!;

            public string ThoiGianLamViecTuThus { get; set; } = null!;

            public string ThoiGianLamViecDenThus { get; set; } = null!;

            public TimeOnly ThoiGianLamViecTuGios { get; set; }

            public TimeOnly ThoiGianLamViecDenGios { get; set; }

            public string HoTenNguoiNhans { get; set; } = null!;

            public string SoDienThoaiNguoiNhans { get; set; } = null!;

            public string EmailNguoiNhans { get; set; } = null!;

            public int IdNhaTuyenDungs { get; set; }

            public int ViTriChuyenMons { get; set; }

            public int ChiTietDiaDiemLamViecs { get; set; }
        }

    }
}
