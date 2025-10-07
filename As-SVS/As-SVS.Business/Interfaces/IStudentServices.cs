using As_SVS.Core.Models;
using As_SVS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddNewAsync(StudentDTO DTO);
        Task<bool> UpdateAsync(StudentDTO entity);
        Task<bool> DeleteAsync(int id);
    }
}
