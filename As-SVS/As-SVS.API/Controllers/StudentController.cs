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

        [HttpPost("complete-profile/{userId}",Name = "complete-student-profile")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CompleteProfile(string userId, StudentProfile student)
        {
            if (string.IsNullOrEmpty(userId) || student is null)
                return BadRequest("Invalid Data");
            int studentId = await _studentServices.AddNewAsync(student, userId);
            if (studentId == -1)
                return StatusCode(500, "Something went wrong");
            return CreatedAtRoute($"complete-student-profile", studentId);
        }

        [HttpDelete("delete-account")]

        public async Task<IActionResult> DeleteAccountAsync(int studentId)
        {
            if (studentId < 1)
                return BadRequest("Invalid data");
            if (!await _studentServices.DeleteStudentAsync(studentId))
                return StatusCode(500, new { error = "something went wrong" });
            return Ok("account has been deleted");
        }
    }
}
