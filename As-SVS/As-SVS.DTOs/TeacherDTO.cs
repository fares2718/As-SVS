using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Specialization { get; set; } = null!;
        
        public string NationalNumber { get; set; } = null!;

        public string TeacherCode { get; set; } = null!;

        public string Qualifications { get; set; } = null!;

        public int GradesId { get; set; }

        public string? Feedbacks { get; set; }

        public decimal Salary { get; set; }
    }
}
