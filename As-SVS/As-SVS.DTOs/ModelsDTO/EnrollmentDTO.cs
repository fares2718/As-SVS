using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class EnrollmentDTO
    {
        public string Student {  get; set; } = string.Empty;
        public string Course {  get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; }
    }
}
