namespace As_SVS.Business.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepository _courseRepository;

        public CourseServices(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<CourseDTO> GetByIdAsync(int Id)
        {
            return await _courseRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<CourseDTO>> SearchByNameAsync(string name)
        {
            return await _courseRepository.SearchByNameAsync(name);
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetEnrolledCourses(int studentId)
        {
            return await _courseRepository.GetEnrolledCoursesAsync(studentId); 
        }

        public async Task EnrollInCourseAsync(int studentId, int courseId)
        {
            await _courseRepository.EnrollInCourseAsync(studentId, courseId); 
        }

        public bool IsStudentEnrolled(int studentId, int courseId)
        {
            return _courseRepository.IsStudentEnrolled(studentId, courseId);
        }
    }
}
