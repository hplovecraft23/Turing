using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class StockMovTypes
    {
        public StockMovTypes()
        {
            StockMovs = new HashSet<StockMovs>();
        }

        public int IdStockMovTypes { get; set; }
        public string StockMovTypeName { get; set; }

        public virtual ICollection<StockMovs> StockMovs { get; set; }
    }
}
