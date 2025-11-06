namespace As_SVS.Core.Interfaces
{
    public interface IQuizeRepository
    {
        Task<int> AddNewAsync(Quize quize,int courseId,int moduleId);
        Task<QuizeDTO> GetQuizeToAttemoAsync(int courseId,int moduleId);
        Task AttempQuize(StudentQuizAttemp studentQuizAttemp);
    }
}
