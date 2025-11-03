using As_SVS.Business.Interfaces;
using As_SVS.DTOs.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost("complete-profile/{userId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CompleteProfile(string userId, StudentDTO student)
        {
            if (string.IsNullOrEmpty(userId) || student is null)
                return BadRequest("Invalid Data");
            int studentId = await _studentServices.AddNewAsync(student, userId);
            return CreatedAtRoute($"complete-profile/{userId}", studentId);
        }
    }
}
