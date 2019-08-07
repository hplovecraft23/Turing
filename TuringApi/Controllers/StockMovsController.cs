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
    public class StockMovsController : ControllerBase
    {
        private readonly TuringContext _context;

        public StockMovsController(TuringContext context)
        {
            _context = context;
        }

        // GET: api/StockMovs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockMov>>> GetStockMovs()
        {
            return await _context.StockMovs.ToListAsync();
        }

        // GET: api/StockMovs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockMov>> GetStockMov(int id)
        {
            var stockMov = await _context.StockMovs.FindAsync(id);

            if (stockMov == null)
            {
                return NotFound();
            }

            return stockMov;
        }

        // PUT: api/StockMovs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockMov(int id, StockMov stockMov)
        {
            if (id != stockMov.ID)
            {
                return BadRequest();
            }

            _context.Entry(stockMov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockMovExists(id))
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

        // POST: api/StockMovs
        [HttpPost]
        public async Task<ActionResult<StockMov>> PostStockMov(StockMov stockMov)
        {
            _context.StockMovs.Add(stockMov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockMov", new { id = stockMov.ID }, stockMov);
        }

        // DELETE: api/StockMovs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockMov>> DeleteStockMov(int id)
        {
            var stockMov = await _context.StockMovs.FindAsync(id);
            if (stockMov == null)
            {
                return NotFound();
            }

            _context.StockMovs.Remove(stockMov);
            await _context.SaveChangesAsync();

            return stockMov;
        }

        private bool StockMovExists(int id)
        {
            return _context.StockMovs.Any(e => e.ID == id);
        }
    }
}
