using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface ICourseServices
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int Id);
        Task<IEnumerable<Course>> SearchByNameAsync(string name);
        Task<IEnumerable<Course>> GetEnrolledCourses(int studentId);
        Task EnrollInCourseAsync(int studentId, int courseId);
    }
}
