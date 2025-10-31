using As_SVS.DTOs.ImageDTO;
using As_SVS.DTOs.VideoDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IVideoServices
    {
        VideoFile GetVideo(string videoFile,string courseName);
        Task<string> UploadVideoToDatabase(IFormFile videoFile, int courseId, int moduleId, int lessonId);
    }
}
