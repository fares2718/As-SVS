using As_SVS.Business.Helpers;
using As_SVS.Business.Interfaces;
using As_SVS.Core.Consts;
using As_SVS.DTOs.ImageDTO;
using As_SVS.DTOs.VideoDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Services
{
    public class VideoServices : IVideoServices
    {
        public VideoFile GetVideo(string videoFile,string courseName)
        {
            var filePath = Path.Combine($"{VideoSettings.videoPath}/{courseName}", videoFile);

            if (!System.IO.File.Exists(filePath))
                return null;
            var video = System.IO.File.OpenRead(filePath);
            var MimeType = Utl.GetMimeType(filePath);

            return new VideoFile
            {
                videoFile = video,
                mimeType = MimeType
            };
        }

    }
}
