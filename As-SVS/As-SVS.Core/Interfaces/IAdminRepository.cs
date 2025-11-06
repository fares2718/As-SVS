namespace As_SVS.Core.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> AddNewAsync(Admin entity);
        Task<IEnumerable<AdminDTO>> GetAllAsync();
        Task<AdminDTO> GetByIdAsync(int Id);
        Task<IEnumerable<AdminDTO>> SearchByNameAsync(string name);
        Task<bool> UpdateAdminSalaryAsync(int adminId,decimal newSalary);
    }
}
