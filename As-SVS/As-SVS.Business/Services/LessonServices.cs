using As_SVS.DTOs.ModelsDTO;
using As_SVS.DTOs.VideoDTO;

namespace As_SVS.Business.Services
{
    public class LessonServices : ILessonsServices
    {
        private readonly ILessonsRepository _lessonsRepository;
        private readonly IVideoServices _videoServices;
        private readonly IMapper _mapper;

        public LessonServices(ILessonsRepository lessonsRepository, IMapper mapper, IVideoServices videoServices)
        {
            _lessonsRepository = lessonsRepository;
            _mapper = mapper;
            _videoServices = videoServices;
        }

        public async Task<int> AddNewAsync(LessonDTO lessonDto, int courseId, int moduleId)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);
            return await _lessonsRepository.AddNewAsync(lesson, courseId, moduleId);
        }

        public async Task<bool> DeleteLessonAsync(int Id,string videoFile, string courseName)
        {
            if(!_videoServices.DeleteVideo(videoFile,courseName))
                return false;
            return await _lessonsRepository.DeleteLessonAsync(Id);
        }

        public async Task<bool> UpdateLessonAsync(UpdateLessonDTO updatedLessonDTO)
        {
            if(!_videoServices.DeleteVideo(updatedLessonDTO.Name,updatedLessonDTO.CourseName))
                return false;
            var updatedLesson = _mapper.Map<Lesson>(updatedLessonDTO);
            return await _lessonsRepository.UpdateLessonAsync(updatedLesson);
        }
    }
}
