using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using BackEnd.Entity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongTiesController : ControllerBase
    {
        private static object lockObject = new object();
        private readonly DbQlcvContext _context;

        public CongTiesController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/CongTies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongTy>>> GetCongTies()
        {
            return await _context.CongTies.ToListAsync();
        }

        // GET: api/CongTies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CongTy>> GetCongTy(int id)
        {
            var congTy = await _context.CongTies.FindAsync(id);

            if (congTy == null)
            {
                return NotFound();
            }

            return congTy;
        }

        // PUT: api/CongTies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCongTy(int id, CongTy congTy)
        {
            if (id != congTy.IdCongTy)
            {
                return BadRequest();
            }

            _context.Entry(congTy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongTyExists(id))
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

        // POST: api/CongTies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CongTy>> PostCongTy(CongTyDAO ctyDAO)
        {
            // Kiểm tra dữ liệu đầu vào (validation cơ bản)
            if (ctyDAO == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }
            int idCty = GenerateUniqueId(); 

            // Chuyển đổi dữ liệu từ DTO (Data Transfer Object) sang Entity
            var congTy = new CongTy
            {
                IdCongTy = idCty, 
                LogoUrl = ctyDAO.LogoUrl,
                TenCongTy = ctyDAO.TenCongTy,
                MaSoThue = ctyDAO.MaSoThue,
                WebsiteUrl = ctyDAO.WebsiteUrl,
                SoLuongNguoiTheoDoi = ctyDAO.SoLuongNguoiTheoDoi,
                QuyMoCongTy = ctyDAO.QuyMoCongTy,
                MoTaCongTy = ctyDAO.MoTaCongTy,
                Email = ctyDAO.Email,
            };

            try
            {
                _context.CongTies.Add(congTy);
                await _context.SaveChangesAsync();


                return CreatedAtAction("GetCongTy", new { id = congTy.IdCongTy }, congTy);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Lỗi khi lưu vào cơ sở dữ liệu: {dbEx.Message}");
                Console.WriteLine($"StackTrace: {dbEx.StackTrace}");
                return StatusCode(500, $"Lỗi: {dbEx.InnerException?.Message ?? dbEx.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi không mong muốn: {ex.Message}");

                return StatusCode(500, "Đã xảy ra lỗi không mong muốn. Vui lòng thử lại sau.");
            }
        }

        // DELETE: api/CongTies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongTy(int id)
        {
            var congTy = await _context.CongTies.FindAsync(id);
            if (congTy == null)
            {
                return NotFound();
            }

            _context.CongTies.Remove(congTy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CongTyExists(int id)
        {
            return _context.CongTies.Any(e => e.IdCongTy == id);
        }

        //Từ id ntd => lay ra cty 

        [HttpGet("CongTy{idNTD}")]
        public async Task<IActionResult> getCongTyByIdNTD(int idNTD)
        {

            var nhaTuyenDung = await _context.NhaTuyenDungs
                               .FirstOrDefaultAsync(ntd => ntd.IdNhaTuyenDung == idNTD);
            if (nhaTuyenDung != null)
            {
                var congTy = await _context.CongTies
                   .FirstOrDefaultAsync(ntd => ntd.IdCongTy == nhaTuyenDung.IdCongTy);

                if (congTy != null)
                    return Ok(congTy);
                else
                    return NotFound();
            }

            else
                return NotFound();
        }


        public static int GenerateUniqueId()
        {
            lock (lockObject) 
            {
                long milliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                return (int)(milliseconds % int.MaxValue); 
            }
        }


    }
}
