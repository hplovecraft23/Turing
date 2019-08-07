using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuringApi.Models
{
    public class StockMov
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public Stock Stock { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Ammount { get; set; }

        [Required]
        public bool GoesOut { get; set; }
        [Required]
        public User User { get; set; }
    }
}
