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
    public interface ITeacherServices
    {
        Task<int> AddNewAsync(TeacherDTO teacherDTO);
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int Id);
        Task<IEnumerable<Teacher>> SearchByNameAsync(string name);
    }
}
