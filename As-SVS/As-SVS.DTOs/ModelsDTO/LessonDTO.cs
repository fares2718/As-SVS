using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int Number { get; set; }
        public string VideoUrl { get; set; } = string.Empty;
        public string LessonDetails { get; set; } = null!;

        public int CourseOrder { get; set; }
    }
}
