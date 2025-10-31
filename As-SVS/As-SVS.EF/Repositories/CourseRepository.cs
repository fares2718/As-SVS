using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.EF;
using Microsoft.EntityFrameworkCore;

namespace AsSVS.EF.Repositories
{
    public class CourseRepository : IBaseRepository<Course> , ICourseRepository
    {
        private readonly As_SVSContext _context;

        
        public CourseRepository(As_SVSContext context)
        {
            _context = context;
        }
        #region User
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Course> GetByIdAsync(int Id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == Id);
            return course ?? new Course();
        }

        public async Task<IEnumerable<Course>> SearchByNameAsync(string name)
        {
            var coursesWithName = await _context.Courses
                .Where(c => c.Name.Contains(name))
                .AsNoTracking()
                .ToListAsync();
            return coursesWithName;
        }

        #endregion

        #region Student
        public async Task<IEnumerable<Course>> GetEnrolledCoursesAsync(int studentId)
        {
            if (!_context.Students.Any(s => s.Id == studentId))
                return new List<Course>();
            else
            {
                var enrolledCourses = await _context.Enrolments
                .Where(e => e.StudentId == studentId)
                .AsNoTracking()
                .ToListAsync();
                return enrolledCourses
                    .Select(ec => ec.Course)
                    .OrderBy(ec => ec.Name);
            }
        }

        public async Task EnrollInCourseAsync(int studentId, int courseId)
        {
            if(!_context.Students.Any(s => s.Id == studentId)
                ||!_context.Courses.Any(c => c.Id == courseId))
            {
                return;
            }
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Id == studentId);
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
            if (student is null || course is null)
                return;
            if (student.GradeId == course.GradeId)
            {
                await _context.Enrolments.AddAsync(
                    new Enrolment
                    {
                        Student = student,
                        Course = course,
                        CourseId = courseId,
                        StudentId = studentId,
                        EnrolmentDate = DateTime.UtcNow
                    });
                await _context.SaveChangesAsync();
            }
        }

        public bool IsStudentEnrolled(int studentId, int courseId)
        {
           var Enrollment = _context.Enrolments.FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);
           return Enrollment != null;
        }

        #endregion
    }
}
