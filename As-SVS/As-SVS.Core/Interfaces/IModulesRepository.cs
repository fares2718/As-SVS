namespace As_SVS.Core.Interfaces
{
    public interface IModulesRepository
    {
        Task<int> AddNewAsync(As_SVS.Core.Models.Module module,int courseId);
    }
}
