namespace As_SVS.Business.Interfaces
{
    public interface IAdminServices
    {
        Task<int> AddNewAsync(AdminDTO adminDTO,string userId);
        Task<IEnumerable<AdminDTO>> GetAllAsync();
        Task<AdminDTO> GetByIdAsync(int Id);
        Task<IEnumerable<AdminDTO>> SearchByNameAsync(string name);
        Task<bool> UpdateAdminSalaryAsync(int adminId, decimal newSalary);
    }
}
