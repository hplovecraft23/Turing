using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuringApi.Models
{
    public class Sell
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public ICollection<Stock> Stocks { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public User User { get; set; }

    }
}
