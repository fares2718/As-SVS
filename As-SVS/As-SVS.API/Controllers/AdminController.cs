using As_SVS.Business.Interfaces;
using As_SVS.DTOs.ModelsDTO;
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
        private readonly IStudentServices _studentServices;

        public AdminController(IAdminServices adminServices, ITeacherServices teacherServices, IStudentServices studentServices)
        {
            _adminServices = adminServices;
            _teacherServices = teacherServices;
            _studentServices = studentServices;
        }

        [HttpPost("complete-profile/{userId}",Name = "complete-admin-profile")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CompleteProfile(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Invalid Data");
            int adminId = await _adminServices.AddNewAsync(userId);
            return CreatedAtRoute($"complete-admin-profile",adminId);
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

        [HttpGet("get-all-students")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAllstudentAsync()
        {
            var students = await _studentServices.GetAllAsync();
            if (!students.Any())
                return NotFound("No student was found");
            return Ok(students);
        }

        [HttpGet("get-student/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetStudentByIdAsync(int studentId)
        {
            if (studentId < 1)
                return BadRequest("Invalid Id");
            var student = await _studentServices.GetByIdAsync(studentId);
            if (student is null || string.IsNullOrEmpty(student.UserName))
                return NotFound("No student was found");
            return Ok(student);
        }

        [HttpGet("get-students-in-grade/{gradeName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetStudentsInGrade(string gradeName)
        {
            if (string.IsNullOrEmpty(gradeName))
                return BadRequest("Invalid grade name");
            var students = await _studentServices.GetInGradeAsync(gradeName);
            if (!students.Any())
                return NotFound("No students was found");
            return Ok(students);
        }

        [HttpGet("search-student/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SearchstudentWithName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Invalid name");
            var students = await _studentServices.SearchByNameAsync(name);
            if (!students.Any())
                return NotFound("No student found with this name");
            return Ok(students);
        }

        [HttpPatch("update-salary")]

        public async Task<IActionResult> UpdateAdminSalary(int adminId,decimal newSalary)
        {
            if (adminId < 1 || newSalary < 0)
                return BadRequest("Invalid data");
            if (!await _adminServices.UpdateAdminSalaryAsync(adminId, newSalary))
                return StatusCode(500,new {error = "Something went wrong"});
            return Ok("salary updated successfully");
        }
    }
}
