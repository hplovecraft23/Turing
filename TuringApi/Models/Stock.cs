using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuringApi.Models
{
    public class Stock
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double SellRatio { get; set; }
        public Categorie Categorie { get; set; }
        public SubCategorie SubCategorie { get; set; }
        public Brand Brand { get; set; }
    }
}
