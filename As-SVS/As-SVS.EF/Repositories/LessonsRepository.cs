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
        private readonly IBaseRepository<Course> _baseRepository;

        public LessonsRepository(As_SVSContext context, IBaseRepository<Course> baseRepository)
        {
            _context = context;
            _baseRepository = baseRepository;
        }

        public async Task<int> AddNewAsync(Lesson lesson, int courseId, int moduleId)
        {
            var course = await _baseRepository.GetByIdAsync(courseId);
            if (course is null)
                return -1;
            var module = course.Modules.FirstOrDefault(m => m.Id == moduleId);
            if (module is null)
                return -1;
            module.Lessons.Add(lesson);
            return lesson.Id;
        }

        public async Task<Lesson> GetLessonsAsync(int courseId, int moduleId, int lessonId)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
            if (course is null)
                return new Lesson();
            var module = course.Modules.SingleOrDefault(m => m.Id == moduleId);
            if (module is null)
                return new Lesson();
            return module.Lessons.SingleOrDefault(l => l.Id == lessonId) ?? new Lesson();
        }

        public async Task<IEnumerable<Lesson>> GetModulesLessonsAsync(int courseId, int moduleId)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
            if(course is null)
                return Enumerable.Empty<Lesson>();
            var module = course.Modules.SingleOrDefault(m => m.Id == moduleId);
            if(module is null)
                return Enumerable.Empty<Lesson>();
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
            return true;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
