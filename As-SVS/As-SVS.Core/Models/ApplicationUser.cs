using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace As_SVS.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Custom {  get; set; }
    }
}
