using As_SVS.Business.Interfaces;
using As_SVS.Core.Consts;
using As_SVS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Services
{
    public class ImageServices : IImageServices
    {
        private readonly IUserRepository _userRepository;

        public ImageServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> UploadImageAsync(IFormFile imageFile,string userId)
        {
            var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(imageFile.FileName)}";
            var path = Path.Combine(ImageSettings.ImagesPath, fileName);

            if(!File.Exists(ImageSettings.ImagesPath))
                Directory.CreateDirectory(ImageSettings.ImagesPath);

            using (var stream = new FileStream(path,FileMode.Create))
                await imageFile.CopyToAsync(stream);

            bool isUploaded = await _userRepository.UploadImageToDatabase(fileName, userId);

            if (!isUploaded)
                return "";

            return path;
        }
    }
}
