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
    public class CashMovTypesController : ControllerBase
    {
        private readonly TuringContext _context;

        public CashMovTypesController(TuringContext context)
        {
            _context = context;
        }

        // GET: api/CashMovTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashMovType>>> GetCashMovTypes()
        {
            return await _context.CashMovTypes.ToListAsync();
        }

        // GET: api/CashMovTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CashMovType>> GetCashMovType(int id)
        {
            var cashMovType = await _context.CashMovTypes.FindAsync(id);

            if (cashMovType == null)
            {
                return NotFound();
            }

            return cashMovType;
        }

        // PUT: api/CashMovTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashMovType(int id, CashMovType cashMovType)
        {
            if (id != cashMovType.ID)
            {
                return BadRequest();
            }

            _context.Entry(cashMovType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashMovTypeExists(id))
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

        // POST: api/CashMovTypes
        [HttpPost]
        public async Task<ActionResult<CashMovType>> PostCashMovType(CashMovType cashMovType)
        {
            _context.CashMovTypes.Add(cashMovType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashMovType", new { id = cashMovType.ID }, cashMovType);
        }

        // DELETE: api/CashMovTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CashMovType>> DeleteCashMovType(int id)
        {
            var cashMovType = await _context.CashMovTypes.FindAsync(id);
            if (cashMovType == null)
            {
                return NotFound();
            }

            _context.CashMovTypes.Remove(cashMovType);
            await _context.SaveChangesAsync();

            return cashMovType;
        }

        private bool CashMovTypeExists(int id)
        {
            return _context.CashMovTypes.Any(e => e.ID == id);
        }
    }
}
