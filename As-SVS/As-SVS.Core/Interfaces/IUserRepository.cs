namespace As_SVS.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string Id);
        Task<bool> UploadImageToDatabase(string fileName,string userId);
    }
}
