using As_SVS.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public TeacherController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        #region OnStudent
        [HttpGet("All-Students-On-Grade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetGradeStudents(int GradeId)
        {
            var studentList = await _studentServices.GetAllInGrade(GradeId);
            if (studentList == null)
                return NotFound("No students was found");
            return Ok(studentList);
        }
        #endregion
    }
}
