using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class StudentProfile
    {
        public string motherName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public int Age { get; }
        public StudentProfile()
        {
            Age = (DateTime.UtcNow.Year - this.DOB.Year);
        }
    }
}
