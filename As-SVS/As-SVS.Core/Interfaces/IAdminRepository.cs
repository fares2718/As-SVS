using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> AddNewAsync(Admin entity);
        Task<IEnumerable<AdminDTO>> GetAllAsync();
        Task<AdminDTO> GetByIdAsync(int Id);
        Task<IEnumerable<AdminDTO>> SearchByNameAsync(string name);
    }
}
