using As_SVS.Business.Helpers;
using As_SVS.Business.Interfaces;
using As_SVS.Core.Consts;
using As_SVS.Core.Interfaces;
using As_SVS.DTOs.VideoDTO;
using Microsoft.AspNetCore.Http;

namespace As_SVS.Business.Services
{
    public class VideoServices : IVideoServices
    {
        public readonly ILessonsRepository _lessonRepository;

        public VideoServices(ILessonsRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public VideoFile GetVideo(string videoFile,string courseName)
        {
            var filePath = Path.Combine($"{VideoSettings.videoPath}/{courseName}", videoFile);

            if (!System.IO.File.Exists(filePath))
                return new VideoFile();
            var video = System.IO.File.OpenRead(filePath);
            var MimeType = Utl.GetMimeType(filePath);

            return new VideoFile
            {
                videoFile = video,
                mimeType = MimeType
            };
        }

        public async Task<string> UploadVideoToDatabase(IFormFile videoFile, int courseId, int moduleId, int lessonId)
        {
            var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(videoFile.FileName)}";
            var path = Path.Combine(ImageSettings.ImagesPath, fileName);

            if (!File.Exists(VideoSettings.videoPath))
                Directory.CreateDirectory(VideoSettings.videoPath);

            using (var stream = new FileStream(path, FileMode.Create))
                await videoFile.CopyToAsync(stream);

            bool isUploaded = await _lessonRepository.UploadVideoToDatabase(fileName, courseId, moduleId,lessonId);

            if (!isUploaded)
                return "";

            return path;
        }
    }
}
