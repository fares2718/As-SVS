namespace As_SVS.Business.Services
{
    public class QuizeServices : IQuizeServices
    {
        private readonly IQuizeRepository _quizeRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public QuizeServices(IQuizeRepository quizeRepository, IMapper mapper, ICourseRepository courseRepository)
        {
            _quizeRepository = quizeRepository;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<int> AddNewAsync(QuizeDTO quizeDto, int courseId, int moduleId)
        { 
            var quize = _mapper.Map<Quize>(quizeDto);

            return await _quizeRepository.AddNewAsync(quize, courseId, moduleId);
        }

        public async Task<QuizeDTO> GetQuizeToAttempAsync(int courseId, int quizeId)
        {
            return await _quizeRepository.GetQuizeToAttemoAsync(courseId, quizeId);
        }

        public async Task<double> AttempQuizeAsync(QuizeAttempDTO quizeAttempDTO, int courseId, int moduleId)
        {
            double quizeGrade = 0;
            foreach(var questionOption in quizeAttempDTO.StudentOptionsNumbers)
            {
                if (questionOption.IsCorrect)
                    quizeGrade += 100 / quizeAttempDTO.StudentOptionsNumbers.Count;
            }
            var studentQuizeAttemp = _mapper.Map<StudentQuizAttemp>(quizeAttempDTO);
            await _quizeRepository.AttempQuize(studentQuizeAttemp);
            return quizeGrade;
        }
    }
}
