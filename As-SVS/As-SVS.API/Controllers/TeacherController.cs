using As_SVS.Business.Interfaces;
using As_SVS.Business.Services;
using As_SVS.DTOs.ModelsDTO;
using As_SVS.DTOs.VideoDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherServices _teacherServices;

        public TeacherController(ITeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
        }

        [HttpPost("complete-profile/{userId}",Name = "complete-teacher-profile")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CompleteProfile(string userId, TeacherProfile teacher)
        {
            if (string.IsNullOrEmpty(userId) || teacher is null)
                return BadRequest("Invalid Data");
            int teacherId = await _teacherServices.AddNewAsync(teacher,userId);
            return CreatedAtRoute($"complete-teacher-profile", teacherId);
        }

        [HttpPatch("update-salary")]

        public async Task<IActionResult> UpdateTeacherSalary(int teacherId, decimal newSalary)
        {
            if (teacherId < 1 || newSalary < 0)
                return BadRequest("Invalid data");
            if (!await _teacherServices.UpdateTeacherSalaryAsync(teacherId, newSalary))
                return StatusCode(500, new { error = "Something went wrong" });
            return Ok("salary updated successfully");
        }
    }
}
