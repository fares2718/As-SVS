using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly IBaseRepository<Course> _baseRepository;
        private readonly ICourseRepository _courseRepository;

        public CourseServices(IBaseRepository<Course> baseRepository, ICourseRepository courseRepository)
        {
            _baseRepository = baseRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<Course> GetByIdAsync(int Id)
        {
            return await _baseRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Course>> SearchByNameAsync(string name)
        {
            return await _baseRepository.SearchByNameAsync(name);
        }

        public async Task<IEnumerable<Course>> GetEnrolledCourses(int studentId)
        {
            return await _courseRepository.GetEnrolledCoursesAsync(studentId); 
        }

        public async Task EnrollInCourseAsync(int studentId, int courseId)
        {
            await _courseRepository.EnrollInCourseAsync(studentId, courseId); 
        }
    }
}
