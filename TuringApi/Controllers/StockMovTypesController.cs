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
    public class StockMovTypesController : ControllerBase
    {
        private readonly TuringContext _context;

        public StockMovTypesController(TuringContext context)
        {
            _context = context;
        }

        // GET: api/StockMovTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockMovType>>> GetStockMovTypes()
        {
            return await _context.StockMovTypes.ToListAsync();
        }

        // GET: api/StockMovTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockMovType>> GetStockMovType(int id)
        {
            var stockMovType = await _context.StockMovTypes.FindAsync(id);

            if (stockMovType == null)
            {
                return NotFound();
            }

            return stockMovType;
        }

        // PUT: api/StockMovTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockMovType(int id, StockMovType stockMovType)
        {
            if (id != stockMovType.ID)
            {
                return BadRequest();
            }

            _context.Entry(stockMovType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockMovTypeExists(id))
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

        // POST: api/StockMovTypes
        [HttpPost]
        public async Task<ActionResult<StockMovType>> PostStockMovType(StockMovType stockMovType)
        {
            _context.StockMovTypes.Add(stockMovType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockMovType", new { id = stockMovType.ID }, stockMovType);
        }

        // DELETE: api/StockMovTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockMovType>> DeleteStockMovType(int id)
        {
            var stockMovType = await _context.StockMovTypes.FindAsync(id);
            if (stockMovType == null)
            {
                return NotFound();
            }

            _context.StockMovTypes.Remove(stockMovType);
            await _context.SaveChangesAsync();

            return stockMovType;
        }

        private bool StockMovTypeExists(int id)
        {
            return _context.StockMovTypes.Any(e => e.ID == id);
        }
    }
}
