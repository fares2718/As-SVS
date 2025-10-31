using As_SVS.Core.Models;


namespace As_SVS.Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetEnrolledCoursesAsync(int studentId);
        Task EnrollInCourseAsync(int studentId,int courseId);
        bool IsStudentEnrolled(int studentId,int courseId);
    }
}
