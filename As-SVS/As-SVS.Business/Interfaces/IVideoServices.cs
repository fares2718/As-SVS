namespace As_SVS.Business.Interfaces
{
    public interface IVideoServices
    {
        public bool DeleteVideo(string videoFile, string courseName);
        VideoFile GetVideo(string videoFile,string courseName);
        Task<string> UploadVideoToDatabase(IFormFile videoFile, int courseId, int moduleId, int lessonId);
    }
}
