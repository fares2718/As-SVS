using As_SVS.Business.Interfaces;
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

        #region Get

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var coursesList = await _courseServices.GetAllAsync();

            if(coursesList.Count()==0)
                return NotFound("No courses was found");

            return Ok(coursesList);
        }

        [HttpGet("GetById/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetCourseByIdAsync(int Id)
        {
            if (Id < 1)
                return BadRequest("Inalid Id");

            var course = await _courseServices.GetByIdAsync(Id);

            if (course is null)
                return NotFound("Course was not found");

            return Ok(course);
        }

        #endregion

    }
}
