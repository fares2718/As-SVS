using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class ModuleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }
        public string Grade { get; set; } = string.Empty;
        public string Teacher { get; set; } = string.Empty;
        public List<LessonDTO> Lessons { get; set; } = new List<LessonDTO>();
        public QuizeDTO Quize { get; set; } = new QuizeDTO();
    }
}
