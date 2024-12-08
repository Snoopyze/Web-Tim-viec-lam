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
    public class CompanyAddressGroupsController : ControllerBase
    {
        private readonly DbQlcvContext _context;

        public CompanyAddressGroupsController(DbQlcvContext context)
        {
            _context = context;
        }

        // GET: api/CompanyAddressGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyAddressGroup>>> GetCompanyAddressGroups()
        {
            return await _context.CompanyAddressGroups.ToListAsync();
        }

        // GET: api/CompanyAddressGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyAddressGroup>> GetCompanyAddressGroup(int id)
        {
            var companyAddressGroup = await _context.CompanyAddressGroups.FindAsync(id);

            if (companyAddressGroup == null)
            {
                return NotFound();
            }

            return companyAddressGroup;
        }

        // PUT: api/CompanyAddressGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyAddressGroup(int id, CompanyAddressGroup companyAddressGroup)
        {
            if (id != companyAddressGroup.IdNhom)
            {
                return BadRequest();
            }

            _context.Entry(companyAddressGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyAddressGroupExists(id))
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

        // POST: api/CompanyAddressGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyAddressGroup>> PostCompanyAddressGroup(CompanyAddressGroup companyAddressGroup)
        {
            _context.CompanyAddressGroups.Add(companyAddressGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyAddressGroupExists(companyAddressGroup.IdNhom))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompanyAddressGroup", new { id = companyAddressGroup.IdNhom }, companyAddressGroup);
        }

        // DELETE: api/CompanyAddressGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyAddressGroup(int id)
        {
            var companyAddressGroup = await _context.CompanyAddressGroups.FindAsync(id);
            if (companyAddressGroup == null)
            {
                return NotFound();
            }

            _context.CompanyAddressGroups.Remove(companyAddressGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyAddressGroupExists(int id)
        {
            return _context.CompanyAddressGroups.Any(e => e.IdNhom == id);
        }
    }
}
