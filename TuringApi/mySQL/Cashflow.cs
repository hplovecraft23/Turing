using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class Cashflow
    {
        public int IdCashFlow { get; set; }
        public double? CashFlowAmmount { get; set; }
        public byte? CashFlowIsClosed { get; set; }
        public DateTime? CashFlowTime { get; set; }
        public string CashflowUser { get; set; }
        public string CashFlowcol { get; set; }
        public int? CashFlowClosesIdCashFlowCloses { get; set; }
        public int? CashFlowTypesIdCashFlowTypes { get; set; }
        public int? StockMovsIdStockMovs { get; set; }

        public virtual CashflowCloses CashFlowClosesIdCashFlowClosesNavigation { get; set; }
        public virtual CashflowTypes CashFlowTypesIdCashFlowTypesNavigation { get; set; }
        public virtual StockMovs StockMovsIdStockMovsNavigation { get; set; }
    }
}
