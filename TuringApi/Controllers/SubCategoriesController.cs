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
    public class SubCategoriesController : ControllerBase
    {
        private readonly TuringContext _context;

        public SubCategoriesController(TuringContext context)
        {
            _context = context;
        }

        // GET: api/SubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategorie>>> GetSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategorie>> GetSubCategorie(int id)
        {
            var subCategorie = await _context.SubCategories.FindAsync(id);

            if (subCategorie == null)
            {
                return NotFound();
            }

            return subCategorie;
        }

        // PUT: api/SubCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategorie(int id, SubCategorie subCategorie)
        {
            if (id != subCategorie.Id)
            {
                return BadRequest();
            }

            _context.Entry(subCategorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategorieExists(id))
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

        // POST: api/SubCategories
        [HttpPost]
        public async Task<ActionResult<SubCategorie>> PostSubCategorie(SubCategorie subCategorie)
        {
            _context.SubCategories.Add(subCategorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubCategorie", new { id = subCategorie.Id }, subCategorie);
        }

        // DELETE: api/SubCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategorie>> DeleteSubCategorie(int id)
        {
            var subCategorie = await _context.SubCategories.FindAsync(id);
            if (subCategorie == null)
            {
                return NotFound();
            }

            _context.SubCategories.Remove(subCategorie);
            await _context.SaveChangesAsync();

            return subCategorie;
        }

        private bool SubCategorieExists(int id)
        {
            return _context.SubCategories.Any(e => e.Id == id);
        }
    }
}
