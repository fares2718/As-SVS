using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface ICourseServices
    {
        Task<IEnumerable<CourseDTO>> GetAllAsync();
        Task<CourseDTO> GetByIdAsync(int Id);
        Task<IEnumerable<CourseDTO>> SearchByNameAsync(string name);
        Task<IEnumerable<EnrollmentDTO>> GetEnrolledCourses(int studentId);
        Task EnrollInCourseAsync(int studentId, int courseId);
        bool IsStudentEnrolled(int studentId, int courseId);
    }
}
