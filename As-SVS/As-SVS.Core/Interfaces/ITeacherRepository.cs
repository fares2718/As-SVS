using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<int> AddNewAsync(Teacher entity);
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task<TeacherDTO> GetByIdAsync(int Id);
        Task<IEnumerable<TeacherDTO>> SearchByNameAsync(string name);
    }
}
