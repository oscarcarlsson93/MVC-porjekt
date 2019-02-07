using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc02.Models
{
    public class CreateProductVm
    {
        public IEnumerable<SelectListItem> AllCategories { get; set; }
        public Product Product { get; set; }
    }
}
