namespace As_SVS.Business.Interfaces
{
    public interface ILessonsServices
    {
        Task<int> AddNewAsync(LessonDTO lesson, int courseId, int moduleId);
    }
}
