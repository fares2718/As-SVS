namespace As_SVS.Business.Interfaces
{
    public interface IStudentServices 
    {
        Task<int> AddNewAsync(StudentDTO studentDTO, string userId);
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetByIdAsync(int Id);
        Task<IEnumerable<StudentDTO>> GetInGradeAsync(string gradeName);
        Task<IEnumerable<StudentDTO>> SearchByNameAsync(string name);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}
