using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuringApi.TuringLogic
{
    public class CategoriesRepo
    {
        mySQL.TuringContext context;
        public List<mySQL.Categories> GetCategories()
        {
            
            using (context = new mySQL.TuringContext())
            {
                return context.Categories.ToList();
            }
        }
        public void PostCategorie(mySQL.Categories categories)
        {
            using (context = new mySQL.TuringContext())
            {
                context.Categories.Add(categories);
                context.SaveChanges();
            }
        }
    }
}
