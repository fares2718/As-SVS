namespace As_SVS.Business.Services
{
    public class LessonServices : ILessonsServices
    {
        private readonly ILessonsRepository _lessonsRepository;
        private readonly IMapper _mapper;

        public LessonServices(ILessonsRepository lessonsRepository, IMapper mapper)
        {
            _lessonsRepository = lessonsRepository;
            _mapper = mapper;
        }

        public async Task<int> AddNewAsync(LessonDTO lessonDto, int courseId, int moduleId)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);
            return await _lessonsRepository.AddNewAsync(lesson, courseId, moduleId);
        }
    }
}
