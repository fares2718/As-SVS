using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ModelsDTO
{
    public class StudentLessonDTO 
    {
        public int StudentId { get; set; }

        public int LessonId { get; set; }

        public bool IsCompleted { get; set; }

        public DateOnly? CompletionDate { get; set; }
    }
}
