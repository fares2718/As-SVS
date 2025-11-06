namespace As_SVS.Business.Interfaces
{
    public interface IQuizeServices
    {
        Task<int> AddNewAsync(QuizeDTO quizeDto, int courseId, int moduleId);
        Task<double> AttempQuizeAsync(QuizeAttempDTO quizeAttempDTO, int courseId, int moduleId);
        Task<QuizeDTO> GetQuizeToAttempAsync(int courseId, int quizeId);
    }
}
