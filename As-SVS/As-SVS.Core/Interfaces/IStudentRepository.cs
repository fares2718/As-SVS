namespace As_SVS.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<int> AddNewAsync(Student entity);
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetByIdAsync(int Id);
        Task<IEnumerable<StudentDTO>> SearchByNameAsync(string name);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}
