﻿using System;
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
    public class HoatDongsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public HoatDongsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/HoatDongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoatDong>>> GetHoatDongs()
        {
            return await _context.HoatDongs.ToListAsync();
        }

        // GET: api/HoatDongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoatDong>> GetHoatDong(int id)
        {
            var hoatDong = await _context.HoatDongs.FindAsync(id);

            if (hoatDong == null)
            {
                return NotFound();
            }

            return hoatDong;
        }

        // PUT: api/HoatDongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoatDong(int id, HoatDong hoatDong)
        {
            if (id != hoatDong.IdHoatDong)
            {
                return BadRequest();
            }

            _context.Entry(hoatDong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoatDongExists(id))
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

        // POST: api/HoatDongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoatDong>> PostHoatDong(HoatDong hoatDong)
        {
            _context.HoatDongs.Add(hoatDong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HoatDongExists(hoatDong.IdHoatDong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHoatDong", new { id = hoatDong.IdHoatDong }, hoatDong);
        }

        // DELETE: api/HoatDongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoatDong(int id)
        {
            var hoatDong = await _context.HoatDongs.FindAsync(id);
            if (hoatDong == null)
            {
                return NotFound();
            }

            _context.HoatDongs.Remove(hoatDong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoatDongExists(int id)
        {
            return _context.HoatDongs.Any(e => e.IdHoatDong == id);
        }
    }
}
