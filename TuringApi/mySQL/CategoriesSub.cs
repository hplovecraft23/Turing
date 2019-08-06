using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class CategoriesSub
    {
        public CategoriesSub()
        {
            Stock = new HashSet<Stock>();
        }

        public int IdCategoriesSub { get; set; }
        public string CategoriesSubName { get; set; }
        public int? CategoriesIdCategories { get; set; }

        public virtual Categories CategoriesIdCategoriesNavigation { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
