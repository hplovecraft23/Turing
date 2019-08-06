using System;
using System.Collections.Generic;

namespace TuringApi.mySQL
{
    public partial class Customers
    {
        public Customers()
        {
            StockMovs = new HashSet<StockMovs>();
        }

        public int IdCustomers { get; set; }
        public string CustomersName { get; set; }
        public string CustomersEmail { get; set; }
        public string CustomersAddressStreet { get; set; }
        public string CustomersAddressNumber { get; set; }
        public string CustomersAddressDetails { get; set; }
        public string CustomersCuit { get; set; }

        public virtual ICollection<StockMovs> StockMovs { get; set; }
    }
}
