using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class Brands
    {
        public Brands()
        {
            Stock = new HashSet<Stock>();
        }

        public int IdBrands { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Stock> Stock { get; set; }
    }
}
