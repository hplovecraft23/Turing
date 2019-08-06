using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class Categories
    {
        public Categories()
        {
            CategoriesSub = new HashSet<CategoriesSub>();
            Stock = new HashSet<Stock>();
        }

        public int IdCategories { get; set; }
        public string CategoriesName { get; set; }

        public virtual ICollection<CategoriesSub> CategoriesSub { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
