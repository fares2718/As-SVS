using As_SVS.Business.Interfaces;
using As_SVS.DTOs.ModelsDTO;
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
        private readonly ITeacherServices _teacherServices;

        public AdminController(IAdminServices adminServices, ITeacherServices teacherServices)
        {
            _adminServices = adminServices;
            _teacherServices = teacherServices;
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
            int adminId = await _adminServices.AddNewAsync(admin,userId);
            return CreatedAtRoute($"complete-profile/{userId}",adminId);
        }

        [HttpGet("get-all-teachers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAllTeachersAsync()
        {
            var teachers = await _teacherServices.GetAllAsync();
            if (!teachers.Any())
                return NotFound("No teacher was found");
            return Ok(teachers);
        }

        [HttpGet("get-teacher/{teacherId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetTeacherByIdAsync(int teacherId)
        {
            if (teacherId < 1)
                return BadRequest("Invalid Id");
            var teacher = await _teacherServices.GetByIdAsync(teacherId);
            if (teacher is null || string.IsNullOrEmpty(teacher.UserName))
                return NotFound("No teacher was found");
            return Ok(teacher);
        }

        [HttpGet("search-teacher/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SearchTeachersWithName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Invalid name");
            var teachers = await _teacherServices.SearchByNameAsync(name);
            if (!teachers.Any())
                return NotFound("No teacher found with this name");
            return Ok(teachers);
        }
    }
}
