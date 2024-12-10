﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using BackEnd.Entity;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaTuyenDungsController : ControllerBase
    {
        private readonly DbQlcvContext _context;
        private static object lockObject = new object();
        public NhaTuyenDungsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/NhaTuyenDungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaTuyenDung>>> GetNhaTuyenDungs()
        {
            return await _context.NhaTuyenDungs.ToListAsync();
        }

        // GET: api/NhaTuyenDungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaTuyenDung>> GetNhaTuyenDung(int id)
        {
            var nhaTuyenDung = await _context.NhaTuyenDungs.FindAsync(id);

            if (nhaTuyenDung == null)
            {
                return NotFound();
            }

            return nhaTuyenDung;
        }

        // PUT: api/NhaTuyenDungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhaTuyenDung(int id, NhaTuyenDung nhaTuyenDung)
        {
            if (id != nhaTuyenDung.IdNhaTuyenDung)
            {
                return BadRequest();
            }

            _context.Entry(nhaTuyenDung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaTuyenDungExists(id))
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

        // POST: api/NhaTuyenDungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhaTuyenDung>> PostNhaTuyenDung(NhaTuyenDungDTO nhaTuyenDungDto)
        {
            // Tạo đối tượng NhaTuyenDung từ DTO
            var nhaTuyenDung = new NhaTuyenDung
            {
                IdNhaTuyenDung = GenerateUniqueId(), 
                Email = nhaTuyenDungDto.Email,
                SoDienThoai = nhaTuyenDungDto.SoDienThoai,
                MatKhau = nhaTuyenDungDto.MatKhau,
                AnhHoSoUrl = nhaTuyenDungDto.AnhHoSoUrl,
                HoTen = nhaTuyenDungDto.HoTen,
                GioiTinh = nhaTuyenDungDto.GioiTinh,
                IdCongTy = nhaTuyenDungDto.IdCongTy
            }; 

            _context.NhaTuyenDungs.Add(nhaTuyenDung);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                
            }

            return CreatedAtAction("GetNhaTuyenDung", new { id = nhaTuyenDung.IdNhaTuyenDung }, nhaTuyenDung);
        }

        // DELETE: api/NhaTuyenDungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhaTuyenDung(int id)
        {
            var nhaTuyenDung = await _context.NhaTuyenDungs.FindAsync(id);
            if (nhaTuyenDung == null)
            {
                return NotFound();
            }

            _context.NhaTuyenDungs.Remove(nhaTuyenDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhaTuyenDungExists(int id)
        {
            return _context.NhaTuyenDungs.Any(e => e.IdNhaTuyenDung == id);
        }

        public static int GenerateUniqueId()
        {
            lock (lockObject) // Đảm bảo thread-safe
            {
                long milliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                return (int)(milliseconds % int.MaxValue);
            }
        }

    }
}
