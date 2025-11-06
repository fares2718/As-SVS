namespace As_SVS.Business.Interfaces
{
    public interface IAuthServices
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AssignRoleAsync(RoleModel model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        Task<ForgetPasswordDTO> ForgetPassword(ForgetPasswordDTO request);
        Task<RestPasswordDTO> RestPassword(RestPasswordDTO request);
        Task<string> DeactivateUser(RoleModel model);
    }
}
