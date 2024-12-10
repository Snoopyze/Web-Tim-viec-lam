using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongTiesController : ControllerBase
    {
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
        [HttpGet("GetDsCongTy/{id}")]
        public async Task<ActionResult<List<CongTy>>> GetFollowedCompanies(int id)
        {
            var followedCompaniesIds = await _context.TheoDoiCongTies
                .Where(t => t.IdUngVien == id)
                .Select(t => t.IdCongTy)
                .ToListAsync();

            // Lấy thông tin các công ty từ bảng công ty
            var followedCompanies = await _context.CongTies
                .Where(c => followedCompaniesIds.Contains(c.IdCongTy))
                .ToListAsync();

            if (followedCompanies == null || followedCompanies.Count == 0)
            {
                return NotFound("Không có công ty nào được theo dõi.");
            }

            return Ok(followedCompanies);
        }

        [HttpGet("GetDsCongTyBySearch/{search}")]
        public async Task<ActionResult<IEnumerable<object>>> GetSearchCongTy(string search)
        {
            if (string.IsNullOrEmpty(search))
            { 
                return BadRequest("Search parameter is required.");
            }

            // Chuyển search về chữ thường
            var searchLower = search.ToLower();
            bool isNumericSearch = int.TryParse(search, out int searchId);


            var companies = await (from c in _context.CongTies
                                   where c.TenCongTy.ToLower().Contains(searchLower) ||    // Tìm theo tên công ty
                                         c.MoTaCongTy.ToLower().Contains(searchLower) ||  // Tìm theo mô tả công ty
                                         (isNumericSearch && c.IdCongTy == searchId)     // Tìm theo ID công ty (nếu search là số)
                                   select new
                                   {
                                       IdCongTy = c.IdCongTy,
                                       TenCongTy = c.TenCongTy,
                                       LogoUrl = c.LogoUrl,
                                       WebsiteUrl = c.WebsiteUrl,
                                       SoLuongNguoiTheoDoi = c.SoLuongNguoiTheoDoi,
                                       QuyMoCongTy = c.QuyMoCongTy,
                                       MoTaCongTy = c.MoTaCongTy,
                                       Email = c.Email
                                   }).ToListAsync();

            if (companies == null || !companies.Any())
            {
                return NotFound("No companies match your search criteria.");
            }

            return Ok(companies);
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
        public async Task<ActionResult<CongTy>> PostCongTy(CongTy congTy)
        {
            _context.CongTies.Add(congTy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CongTyExists(congTy.IdCongTy))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCongTy", new { id = congTy.IdCongTy }, congTy);
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
    }
}
