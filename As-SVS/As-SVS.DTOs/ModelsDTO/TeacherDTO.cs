using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class TeacherDTO : UserDTO
    {
        public string Specialization { get; set; } = string.Empty;
        public string TeacherCode { get; set; } = null!;
        public string Qualifications { get; set; } = string.Empty;
        public string Feedbacks { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
