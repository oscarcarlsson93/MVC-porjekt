using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc02.Models
{
    public class UserWithRoles
    {
        public IdentityUser IdentityUser { get; set; }
        public List<string> Roles { get; set; }
    }
}
