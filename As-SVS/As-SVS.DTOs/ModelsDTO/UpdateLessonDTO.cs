using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class UpdateLessonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LessonDetails { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
    }
}
