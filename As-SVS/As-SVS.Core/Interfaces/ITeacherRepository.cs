using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface ITeacherRepository
    {
        Task<bool> UpdateTeacherSalary(int Id,decimal salary);
        Task<bool> IsExist(int Id);
    }
}
