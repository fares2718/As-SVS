using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;


namespace As_SVS.Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<int> AddNewAsync(Course entity);
        Task<IEnumerable<CourseDTO>> GetAllAsync();
        Task<CourseDTO> GetByIdAsync(int Id);
        Task<IEnumerable<CourseDTO>> SearchByNameAsync(string name);
        Task<IEnumerable<EnrollmentDTO>> GetEnrolledCoursesAsync(int studentId);
        Task EnrollInCourseAsync(int studentId,int courseId);
        bool IsStudentEnrolled(int studentId,int courseId);
    }
}
