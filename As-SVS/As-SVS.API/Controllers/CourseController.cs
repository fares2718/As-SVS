using As_SVS.Business.Interfaces;
using As_SVS.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices _courseServices;

        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        #region User

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var coursesList = await _courseServices.GetAllAsync();

            if (coursesList.Count() == 0)
                return NotFound("No courses was found");

            return Ok(coursesList);
        }

        [HttpGet("SearchByName/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Invalid name");
            var coursesWithName = await _courseServices.SearchByNameAsync(name);
            if (coursesWithName is null || coursesWithName.Count() == 0)
                return NotFound($"{name} was not found");
            return Ok(coursesWithName);
        }

        #endregion

        #region Student

        [Authorize("Student")]
        [HttpGet("Courses/Enrollements/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEnrolledCourses(int studentId)
        {
            if (studentId < 1)
                return BadRequest("Invalid Id");
            var enrolledCourses = await _courseServices.GetEnrolledCourses(studentId);

            if (enrolledCourses.Count() == 0)
                return NotFound("No course was found");
            return Ok(enrolledCourses);
        }

        [Authorize("Student")]
        [HttpGet("Courses/Enroll/{studentId}/{courseId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> EnrollInCourseAsync(int studentId, int courseId)
        {
            if (studentId < 1 || courseId < 1)
                return BadRequest("Invalid student Id or course Id");
            await _courseServices.EnrollInCourseAsync(studentId, courseId);
            return CreatedAtRoute("Courses/Enroll",new {studentId,courseId});
        }

        #endregion

    }
}
