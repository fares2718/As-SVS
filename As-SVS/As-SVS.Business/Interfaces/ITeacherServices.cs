using As_SVS.Core.Models;
using As_SVS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface ITeacherServices : IBaseServices<Teacher>
    {
        Task<Teacher?> GetByPersonIdAsync(int id);
        Task<Teacher?> GetByTeacherCode(string code);
        Task<bool> UpdateSalaryAsync(int Id,decimal salary);
        Task<bool> IsExist(int id);
    }
}
