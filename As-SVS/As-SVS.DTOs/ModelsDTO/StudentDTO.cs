using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class StudentDTO : UserDTO
    {
        public string motherName { get; set; } = string.Empty;
        public string studentCode { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public double? Average { get; set; } 

    }
}
