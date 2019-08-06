using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class StockMovs
    {
        public StockMovs()
        {
            Cashflow = new HashSet<Cashflow>();
        }

        public int IdStockMovs { get; set; }
        public int? StockMovAmount { get; set; }
        public string StockMovUsr { get; set; }
        public DateTime? StockMovTime { get; set; }
        public double? StockMovPrice { get; set; }
        public string StockMovscol { get; set; }
        public double? StockMovsSellDiscount { get; set; }
        public int? CustomersIdCustomers { get; set; }
        public int? StockMovTypesIdStockMovTypes { get; set; }
        public int? StockIdStock { get; set; }
        public int? StockSellId { get; set; }

        public virtual Customers CustomersIdCustomersNavigation { get; set; }
        public virtual Stock StockIdStockNavigation { get; set; }
        public virtual StockMovTypes StockMovTypesIdStockMovTypesNavigation { get; set; }
        public virtual ICollection<Cashflow> Cashflow { get; set; }
    }
}
