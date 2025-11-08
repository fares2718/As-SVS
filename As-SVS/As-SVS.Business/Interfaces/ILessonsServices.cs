namespace As_SVS.Business.Interfaces
{
    public interface ILessonsServices
    {
        Task<int> AddNewAsync(LessonDTO lesson, int courseId, int moduleId);
        Task<bool> UpdateLessonAsync(UpdateLessonDTO updatedLessonDTO);
        Task<bool> DeleteLessonAsync(int Id, string videoFile, string courseName);
    }
}
