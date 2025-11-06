namespace As_SVS.Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<int> AddNewAsync(Teacher entity);
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task<TeacherDTO> GetByIdAsync(int Id);
        Task<IEnumerable<TeacherDTO>> SearchByNameAsync(string name);
        Task<bool> UpdateTeacherSalaryAsync(int teacherId, decimal newSalary);
    }
}
