namespace As_SVS.Business.Interfaces
{
    public interface IImageServices
    {
        Task<string> UploadImageAsync(IFormFile imageFile,string userId);
        ImageFile GetImage(string imageFile);
    }
}
