namespace As_SVS.Business.Services
{
    public class ImageServices : IImageServices
    {
        private readonly IUserRepository _userRepository;

        public ImageServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ImageFile GetImage(string imageFile)
        {
            var filePath = Path.Combine(ImageSettings.ImagesPath, imageFile);

            if (!System.IO.File.Exists(filePath))
                return new ImageFile { };
            var image = System.IO.File.OpenRead(filePath);
            var MimeType = Utl.GetMimeType(filePath);

            return new ImageFile 
            { 
                imageFile = image,
                mimeType = MimeType
            };
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
