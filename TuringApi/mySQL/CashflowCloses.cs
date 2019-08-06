using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class CashflowCloses
    {
        public CashflowCloses()
        {
            Cashflow = new HashSet<Cashflow>();
        }

        public int IdCashFlowCloses { get; set; }
        public DateTime? CashFlowClosesDate { get; set; }
        public string CashFlowClosesUsr { get; set; }
        public string CashFlowClosescol { get; set; }

        public virtual ICollection<Cashflow> Cashflow { get; set; }
    }
}
