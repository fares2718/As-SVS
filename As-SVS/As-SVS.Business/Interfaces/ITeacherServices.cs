using As_SVS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface ITeacherServices
    {
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task<TeacherDTO> GetByIdAsync(int id);
        Task<TeacherDTO> AddNewAsync(TeacherDTO DTO);
        Task<bool> UpdateAsync(TeacherDTO entity);
        Task<bool> DeleteAsync(int id);
    }
}
