using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string primarySkill { get; set; }
    }
}
