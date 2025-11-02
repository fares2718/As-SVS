using As_SVS.DTOs.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IModulesServices
    {
        Task<int> AddNewAsync(ModuleDTO module, int courseId);
    }
}
