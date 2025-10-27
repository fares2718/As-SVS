using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Models
{
    public class TokenRequestModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
