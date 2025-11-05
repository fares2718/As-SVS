using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IAuthServices
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AssignRoleAsync(AssignRoleModel model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        Task<ForgetPasswordDTO> ForgetPassword(ForgetPasswordDTO request);
        Task<RestPasswordDTO> RestPassword(RestPasswordDTO request);
    }
}
