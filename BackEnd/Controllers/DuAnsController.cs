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
    public class DuAnsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public DuAnsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/DuAns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DuAn>>> GetDuAns()
        {
            return await _context.DuAns.ToListAsync();
        }

        // GET: api/DuAns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DuAn>> GetDuAn(int id)
        {
            var duAn = await _context.DuAns.FindAsync(id);

            if (duAn == null)
            {
                return NotFound();
            }

            return duAn;
        }

        // PUT: api/DuAns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuAn(int id, DuAn duAn)
        {
            if (id != duAn.IdDuAn)
            {
                return BadRequest();
            }

            _context.Entry(duAn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuAnExists(id))
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

        // POST: api/DuAns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DuAn>> PostDuAn(DuAn duAn)
        {
            _context.DuAns.Add(duAn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DuAnExists(duAn.IdDuAn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDuAn", new { id = duAn.IdDuAn }, duAn);
        }

        // DELETE: api/DuAns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuAn(int id)
        {
            var duAn = await _context.DuAns.FindAsync(id);
            if (duAn == null)
            {
                return NotFound();
            }

            _context.DuAns.Remove(duAn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DuAnExists(int id)
        {
            return _context.DuAns.Any(e => e.IdDuAn == id);
        }
    }
}
