using As_SVS.Business.Interfaces;
using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using AutoMapper;

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

        public async Task<Lesson> GetLessonsAsync(int courseId, int moduleId, int lessonId)
        {
            return await _lessonsRepository.GetLessonsAsync(courseId, moduleId, lessonId);
        }
    }
}
