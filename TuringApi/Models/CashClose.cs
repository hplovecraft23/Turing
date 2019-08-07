using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuringApi.Models
{
    public class CashClose
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ICollection<CashMov> CashMovs { get; set; }
        [Required]
        public double DayFlow { get; set; }
        [Required]
        public double RepositionCost { get; set; }
        [Required]
        public User User { get; set; }
    }
}
