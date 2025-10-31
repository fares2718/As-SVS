using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly As_SVSContext _context;

        public LessonsRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetModulesLessons(int moduleId)
        {
            var module = await _context.Modules.SingleOrDefaultAsync(m => m.Id == moduleId);
            if(module is null)
                return new List<Lesson>();
            return module.Lessons;
        }

        public async Task<bool> UploadVideoToDatabase(string fileName, int courseId,int moduleId, int lessonId)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(
                c => c.Id == courseId);

            if (course is null)
                return false;

            var module = course.Modules.SingleOrDefault(m => m.Id == moduleId);

            if(module is null)
                return false;

            var lesson = module.Lessons.FirstOrDefault(l => l.Id == lessonId);

            if (lesson is null)
                return false;

            lesson.VideoUrl = fileName;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
