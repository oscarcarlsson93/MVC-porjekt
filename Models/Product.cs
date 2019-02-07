using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc02.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Du glömde fylla i Namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Du glömde fylla i pris")]
        [Range(0, 1000, ErrorMessage ="Priset måste vara mellan 0 och 1000")]

        public decimal Price { get; set; }
        public bool ForSale { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}

