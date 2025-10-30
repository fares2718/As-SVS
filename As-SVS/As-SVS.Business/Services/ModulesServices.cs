using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Services
{
    public class ModulesServices : IModulesServices
    {
        private readonly IModulesRepository _modulesRepository;

        public ModulesServices(IModulesRepository modulesRepository)
        {
            _modulesRepository = modulesRepository;
        }

        public async Task<IEnumerable<Module>> GetAllModulesInCourseAsync(int courseId)
        {
            return await _modulesRepository.GetAllModulesInCourseAsync(courseId);
        }
    }
}
