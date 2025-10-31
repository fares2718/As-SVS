using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using AutoMapper;

namespace As_SVS.Business.Services
{
    public class ModulesServices : IModulesServices
    {
        private readonly IModulesRepository _modulesRepository;
        private readonly IMapper _mapper;

        public ModulesServices(IModulesRepository modulesRepository, IMapper mapper)
        {
            _modulesRepository = modulesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Module>> GetAllModulesInCourseAsync(int courseId)
        {
            return await _modulesRepository.GetAllModulesInCourseAsync(courseId);
        }

        public async Task<int> AddNewAsync(ModuleDTO moduleDTO,int courseId)
        {
            var module = _mapper.Map<Module>(moduleDTO);
            return await _modulesRepository.AddNewAsync(module, courseId);
        }
    }
}
