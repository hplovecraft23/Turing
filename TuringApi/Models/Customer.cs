using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuringApi.Models
{
    public class Customer
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address_Street { get; set; }
        public string Address_Number { get; set; }
        public string Adress_Detail { get; set; }
        public string CUIL { get; set; }

    }
}
