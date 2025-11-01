using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface ILessonsServices
    {
        Task<int> AddNewAsync(LessonDTO lesson, int courseId, int moduleId);
        Task<Lesson> GetLessonsAsync(int courseId, int moduleId, int lessonId);
        Task SaveAsync();
    }
}
