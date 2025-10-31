using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using AutoMapper;

namespace As_SVS.Business.Services
{
    public class QuizeServices : IQuizeServices
    {
        private readonly IQuizeRepository _quizeRepository;
        private readonly IMapper _mapper;
        public QuizeServices(IQuizeRepository quizeRepository, IMapper mapper)
        {
            _quizeRepository = quizeRepository;
            _mapper = mapper;
        }

        public async Task<int> AddNewAsync(QuizeDTO quizeDto, int courseId, int moduleId)
        { 
            var quize = _mapper.Map<Quize>(quizeDto);

            return await _quizeRepository.AddNewAsync(quize, courseId, moduleId);
        }
    }
}
