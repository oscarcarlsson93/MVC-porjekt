using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc02.Models.ViewModels
{
    public class ContactUsVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Question { get; set; }
    }
}
