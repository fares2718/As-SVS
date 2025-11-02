using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public List<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();
    }
}
