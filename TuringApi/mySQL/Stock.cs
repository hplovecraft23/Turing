using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class Stock
    {
        public Stock()
        {
            StockMovs = new HashSet<StockMovs>();
        }

        public int IdStock { get; set; }
        public string StockName { get; set; }
        public double? StockBuyPrice { get; set; }
        public double? StockSellRatio { get; set; }
        public int? BrandsIdBrands { get; set; }
        public int? CategoriesIdCategories { get; set; }
        public int? CategoriesSubIdCategoriesSub { get; set; }

        public virtual Brands BrandsIdBrandsNavigation { get; set; }
        public virtual Categories CategoriesIdCategoriesNavigation { get; set; }
        public virtual CategoriesSub CategoriesSubIdCategoriesSubNavigation { get; set; }
        public virtual ICollection<StockMovs> StockMovs { get; set; }
    }
}
