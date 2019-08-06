using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TuringApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        mySQL.TuringContext Context;
        // GET: api/Categories
        [HttpGet]
        public IEnumerable<mySQL.Categories> Get()
        {
            using (Context = new mySQL.TuringContext())
            {
                return Context.Categories.ToList();
            }
             
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody] string name)
        {
            using (Context = new mySQL.TuringContext())
            {
                mySQL.Categories categories = new mySQL.Categories
                {
                    CategoriesName = name,
                };
                Context.Categories.Add(categories);
                Context.SaveChanges();
            }
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
