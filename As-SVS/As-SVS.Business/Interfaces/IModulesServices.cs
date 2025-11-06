namespace As_SVS.Business.Interfaces
{
    public interface IModulesServices
    {
        Task<int> AddNewAsync(ModuleDTO module, int courseId);
    }
}
