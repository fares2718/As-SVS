using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<int> AddNewAsync(Student entity);
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetByIdAsync(int Id);
        Task<IEnumerable<StudentDTO>> SearchByNameAsync(string name);
    }
}
