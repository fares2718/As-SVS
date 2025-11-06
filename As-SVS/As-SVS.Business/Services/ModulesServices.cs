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

        public async Task<int> AddNewAsync(ModuleDTO moduleDTO,int courseId)
        {
            var module = _mapper.Map<Module>(moduleDTO);
            return await _modulesRepository.AddNewAsync(module, courseId);
        }
    }
}
