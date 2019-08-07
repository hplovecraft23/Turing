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
    public class CashClosesController : ControllerBase
    {
        private readonly TuringContext _context;

        public CashClosesController(TuringContext context)
        {
            _context = context;
        }

        // GET: api/CashCloses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashClose>>> GetCashCloses()
        {
            return await _context.CashCloses.ToListAsync();
        }

        // GET: api/CashCloses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CashClose>> GetCashClose(int id)
        {
            var cashClose = await _context.CashCloses.FindAsync(id);

            if (cashClose == null)
            {
                return NotFound();
            }

            return cashClose;
        }

        // PUT: api/CashCloses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashClose(int id, CashClose cashClose)
        {
            if (id != cashClose.ID)
            {
                return BadRequest();
            }

            _context.Entry(cashClose).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashCloseExists(id))
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

        // POST: api/CashCloses
        [HttpPost]
        public async Task<ActionResult<CashClose>> PostCashClose(CashClose cashClose)
        {
            _context.CashCloses.Add(cashClose);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashClose", new { id = cashClose.ID }, cashClose);
        }

        // DELETE: api/CashCloses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CashClose>> DeleteCashClose(int id)
        {
            var cashClose = await _context.CashCloses.FindAsync(id);
            if (cashClose == null)
            {
                return NotFound();
            }

            _context.CashCloses.Remove(cashClose);
            await _context.SaveChangesAsync();

            return cashClose;
        }

        private bool CashCloseExists(int id)
        {
            return _context.CashCloses.Any(e => e.ID == id);
        }
    }
}
