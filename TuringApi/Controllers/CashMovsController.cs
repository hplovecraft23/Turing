using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuringApi.Models;

namespace TuringApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashMovsController : ControllerBase
    {
        private readonly TuringContext _context;

        public CashMovsController(TuringContext context)
        {
            _context = context;
        }

        // GET: api/CashMovs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashMov>>> GetCashMovs()
        {
            return await _context.CashMovs.ToListAsync();
        }

        // GET: api/CashMovs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CashMov>> GetCashMov(int id)
        {
            var cashMov = await _context.CashMovs.FindAsync(id);

            if (cashMov == null)
            {
                return NotFound();
            }

            return cashMov;
        }

        // PUT: api/CashMovs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashMov(int id, CashMov cashMov)
        {
            if (id != cashMov.ID)
            {
                return BadRequest();
            }

            _context.Entry(cashMov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashMovExists(id))
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

        // POST: api/CashMovs
        [HttpPost]
        public async Task<ActionResult<CashMov>> PostCashMov(CashMov cashMov)
        {
            _context.CashMovs.Add(cashMov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashMov", new { id = cashMov.ID }, cashMov);
        }

        // DELETE: api/CashMovs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CashMov>> DeleteCashMov(int id)
        {
            var cashMov = await _context.CashMovs.FindAsync(id);
            if (cashMov == null)
            {
                return NotFound();
            }

            _context.CashMovs.Remove(cashMov);
            await _context.SaveChangesAsync();

            return cashMov;
        }

        private bool CashMovExists(int id)
        {
            return _context.CashMovs.Any(e => e.ID == id);
        }
    }
}
