using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuringApi.Models
{
    public class CashMov
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public double Ammount { get; set; }
        public bool Closed { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public CashMovType CashMovType { get; set; }
        [Required]
        public User User { get; set; }
    }
}
