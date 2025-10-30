using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface IModulesRepository
    {
        Task<IEnumerable<As_SVS.Core.Models.Module>>GetAllModulesInCourseAsync(int courseId);
    }
}
