using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int GradeId { get; set; }

        public string MotherName { get; set; } = null!;

        public double? Average { get; set; }

        public string StudentCode { get; set; } = null!;
    }
}
