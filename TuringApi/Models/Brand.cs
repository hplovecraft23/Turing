using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuringApi.Models
{
    public class Brand
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
