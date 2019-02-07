using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc02.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Du glömde fylla i")]
        public string Name { get; set; }
    }
}
