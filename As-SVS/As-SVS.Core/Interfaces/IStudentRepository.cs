using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetByStudentCode(string code);
        Task<IEnumerable<Student>> GetAllInGrade(int GradeId);
    }
}
