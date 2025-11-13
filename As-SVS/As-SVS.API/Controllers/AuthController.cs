using As_SVS.Business.Interfaces;
using As_SVS.Business.Services;
using As_SVS.Core.Models;
using As_SVS.DTOs.ModelsDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authService;

        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }

        #region POST
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if(!string.IsNullOrEmpty(result.RefreshToken))
                AppendRefreshTokenToCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if (!string.IsNullOrEmpty(result.RefreshToken))
                AppendRefreshTokenToCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("assign-role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AssignRoleAsync([FromBody] RoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AssignRoleAsync(model);

            if(!string.IsNullOrWhiteSpace(result))
                return BadRequest(result);

            return Ok(model);
        }

        [HttpPost("revokeToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> RevokeToken([FromBody] RevokeToken dto)
        {
            var token = dto.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is requiered");

            var result = await _authService.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is Invalid");

            return Ok("Great");
        }

        [HttpPost("forget-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDTO request)
        {
            if(!ModelState.IsValid || request is null)
                return BadRequest("Invalid data");
            await _authService.ForgetPassword(request);
            if (string.IsNullOrEmpty(request.Token))
                return BadRequest("Something went wrong");
            /*
             send email functionalty
             */
            return Ok(request);
        }

        [HttpPost("rest-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> RestPassword(RestPasswordDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _authService.RestPassword(request);
            if (string.IsNullOrEmpty(request.Token) || string.IsNullOrEmpty(request.Email))
                return BadRequest(request.Message);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string token)
        {
            await _authService.RevokeTokenAsync(token);
            return Ok(new { message = "Logged out successfully" });
        }

        #endregion

        #region GET

        [HttpGet("refreshToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> RefreshTokenAsync()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshToken))
                return BadRequest("Something went wrong");

            var result = await _authService.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            if(!string.IsNullOrEmpty(result.RefreshToken))
                AppendRefreshTokenToCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        #endregion

        private void AppendRefreshTokenToCookie(string RefreshToken,DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };
            Response.Cookies.Append("refreshToken", RefreshToken, cookieOptions);
        }
    }
}
