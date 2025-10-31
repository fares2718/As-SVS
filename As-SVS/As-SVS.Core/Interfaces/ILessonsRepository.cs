using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface ILessonsRepository
    {
        Task<IEnumerable<Lesson>> GetModulesLessonsAsync(int courseId, int moduleId);
        Task<Lesson> GetLessonsAsync(int courseId, int moduleId,int lessonId);
        Task<bool> UploadVideoToDatabase(string fileName, int courseId, int moduleId, int lessonId);
    }
}
