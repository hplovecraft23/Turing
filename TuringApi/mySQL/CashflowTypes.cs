using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class CashflowTypes
    {
        public CashflowTypes()
        {
            Cashflow = new HashSet<Cashflow>();
        }

        public int IdCashFlowTypes { get; set; }
        public string CashFlowTypesName { get; set; }

        public virtual ICollection<Cashflow> Cashflow { get; set; }
    }
}
