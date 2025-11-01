using As_SVS.Business.Interfaces;
using As_SVS.DTOs.VideoDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpPost("complete-profile/{userId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CompleteProfile(string userId,AdminDTO admin)
        {
            if (string.IsNullOrEmpty(userId) || admin is null)
                return BadRequest("Invalid Data");
            int adminId = await _adminServices.AddNewAsync(admin);
            return CreatedAtRoute($"complete-profile/{userId}",adminId);
        }
    }
}
