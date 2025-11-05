using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IQuizeServices
    {
        Task<int> AddNewAsync(QuizeDTO quizeDto, int courseId, int moduleId);
        Task<double> AttempQuizeAsync(QuizeAttempDTO quizeAttempDTO, int courseId, int moduleId);
        Task<QuizeDTO> GetQuizeToAttempAsync(int courseId, int quizeId);
    }
}
