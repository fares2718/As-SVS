namespace As_SVS.Business.Interfaces
{
    public interface ITeacherServices
    {
        Task<int> AddNewAsync(TeacherProfile teacherDTO,string userId);
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task<TeacherDTO> GetByIdAsync(int Id);
        Task<IEnumerable<TeacherDTO>> SearchByNameAsync(string name);
        Task<bool> UpdateTeacherSalaryAsync(int adminId, decimal newSalary);
    }
}
