using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using As_SVS.DTOs.VideoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IAdminServices
    {
        Task<int> AddNewAsync(AdminDTO adminDTO,string userId);
        Task<IEnumerable<AdminDTO>> GetAllAsync();
        Task<AdminDTO> GetByIdAsync(int Id);
        Task<IEnumerable<AdminDTO>> SearchByNameAsync(string name);
    }
}
