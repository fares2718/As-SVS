using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class TeacherDTO
    {
        public string applicationUserId { get; set; } = null!;

        public string? Specialization { get; set; }

        public string TeacherCode { get; set; } = null!;

        public string? Qualifications { get; set; }

        public int GradesId { get; set; }

        public string? Feedbacks { get; set; }

        public decimal Salary { get; set; }
    }
}
