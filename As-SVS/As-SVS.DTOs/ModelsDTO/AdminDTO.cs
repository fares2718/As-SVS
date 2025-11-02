using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class AdminDTO : UserDTO
    {
        public string Role { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
