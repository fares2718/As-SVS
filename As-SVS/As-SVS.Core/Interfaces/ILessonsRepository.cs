namespace As_SVS.Core.Interfaces
{
    public interface ILessonsRepository
    {
        Task<int> AddNewAsync(Lesson lesson,int courseId,int moduleId);
        Task CompleteLessonAsync(StudentLesson studentLesson);
        Task<bool> DeleteLessonAsync(int Id);
        Task<bool> UpdateLessonAsync(Lesson updatedLesson);
        Task<bool> UploadVideoToDatabase(string fileName, int courseId, int moduleId, int lessonId);
    }
}
