namespace As_SVS.Business.Interfaces
{
    public interface IStudentServices 
    {
        Task<int> AddNewAsync(StudentProfile studentDTO, string userId);
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetByIdAsync(int Id);
        Task<IEnumerable<StudentDTO>> GetInGradeAsync(int gradeNumber);
        Task<IEnumerable<StudentDTO>> SearchByNameAsync(string name);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}
