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
    public class UngViensController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public UngViensController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/UngViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UngVien>>> GetUngViens()
        {
            return await _context.UngViens.ToListAsync();
        }

        // GET: api/UngViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UngVien>> GetUngVien(int id)
        {
            var ungVien = await _context.UngViens.FindAsync(id);

            if (ungVien == null)
            {
                return NotFound();
            }

            return ungVien;
        }

        // PUT: api/UngViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUngVien(int id, UngVien ungVien)
        {
            if (id != ungVien.IdUngVien)
            {
                return BadRequest();
            }

            _context.Entry(ungVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UngVienExists(id))
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
        [HttpPut("UpdateUserInfo/{id}")]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] UpdateUserInfoRequest updateRequest)
        {
            // Tìm người dùng theo id
            var ungVien = await _context.UngViens.FindAsync(id);

            // Nếu không cần kiểm tra người dùng có tồn tại, bạn có thể bỏ qua phần này
            if (ungVien == null)
            {
                return NotFound("Người dùng không tồn tại.");
            }

            // Cập nhật các trường cần thiết
            ungVien.HoTen = updateRequest.HoTen ?? ungVien.HoTen; // Cập nhật tên nếu có
            ungVien.SoDienThoai = updateRequest.SoDienThoai ?? ungVien.SoDienThoai; // Cập nhật số điện thoại nếu có

            // Đánh dấu đối tượng là đã sửa đổi để Entity Framework biết
            _context.Entry(ungVien).State = EntityState.Modified;

            try
            {
                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Bắt lỗi và trả về thông báo lỗi nếu có vấn đề khi lưu
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            // Trả về phản hồi thành công
            return NoContent();
        }
        [HttpPut("ChangePassword/{id}")]
        public IActionResult ChangePassword(int id, [FromBody] ChangePasswordRequest request)
        {
            // Tìm ứng viên theo ID
            var ungVien = _context.UngViens.FirstOrDefault(u => u.IdUngVien == id);
            if (ungVien == null)
            {
                return NotFound("Ứng viên không tồn tại.");
            }

            // Kiểm tra mật khẩu hiện tại
            if (ungVien.MatKhau != request.CurrentPassword)
            {
                return BadRequest("Mật khẩu hiện tại không đúng.");
            }

            // Cập nhật mật khẩu mới
            ungVien.MatKhau = request.NewPassword;
            _context.SaveChanges();

            return Ok("Đổi mật khẩu thành công.");
        }
        // POST: api/UngViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UngVien>> PostUngVien(UngVien ungVien)
        {
            _context.UngViens.Add(ungVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UngVienExists(ungVien.IdUngVien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUngVien", new { id = ungVien.IdUngVien }, ungVien);
        }

        // DELETE: api/UngViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUngVien(int id)
        {
            var ungVien = await _context.UngViens.FindAsync(id);
            if (ungVien == null)
            {
                return NotFound();
            }

            _context.UngViens.Remove(ungVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UngVienExists(int id)
        {
            return _context.UngViens.Any(e => e.IdUngVien == id);
        }
    }
}
