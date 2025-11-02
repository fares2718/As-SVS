using As_SVS.Business.Interfaces;
using As_SVS.Core.Models;
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
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices _courseServices;
        private readonly IModulesServices _modulesServices;
        private readonly ILessonsServices _lessonsServices;
        private readonly IQuizeServices _quizeServices;
        private readonly IVideoServices _videoServices;

        public CourseController(ICourseServices courseServices, IModulesServices modulesServices,
            ILessonsServices lessonsServices, IVideoServices videoServices, IQuizeServices quizeServices)
        {
            _courseServices = courseServices;
            _modulesServices = modulesServices;
            _lessonsServices = lessonsServices;
            _videoServices = videoServices;
            _quizeServices = quizeServices;
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

        //[Authorize("Student")]
        [HttpGet("Enrollements/{studentId}")]
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
        //[Authorize("Student")]
        [HttpGet("{courseId}/{moduleId}/{studentId}/watch/{lessonId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> WatchLessonAsync(int studentId,int courseId,int moduleId,int lessonId)
        {
            if (studentId < 1 || courseId < 1 || moduleId < 1 || lessonId < 1)
                return BadRequest("Invalid Data");
            var course = await _courseServices.GetByIdAsync(courseId);
            var lesson = course.Modules.Single(m => m.Id ==  moduleId)
                .Lessons.Single(l => l.Id == lessonId);
            var video = _videoServices.GetVideo(lesson.VideoUrl,course.Name);
            if (string.IsNullOrEmpty(video.mimeType) || video.videoFile is null)
                return StatusCode(500, new { error = "some thing went wrong"});
            return File(video.videoFile,video.mimeType);
        }

        //[Authorize("Student")]
        [HttpPost("Enroll/{studentId}/{courseId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> EnrollInCourseAsync(int studentId, int courseId)
        {
            if (studentId < 1 || courseId < 1)
                return BadRequest("Invalid student Id or course Id");
            await _courseServices.EnrollInCourseAsync(studentId, courseId);
            return CreatedAtRoute("Courses/Enroll", new { studentId, courseId });
        }

        #endregion

        #region Teacher

        //[Authorize("Teacher")]
        [HttpPost("{courseId}/add-module")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> AddNewModuleAsync(ModuleDTO module,int courseId)
        {
            if (courseId < 1 || string.IsNullOrEmpty(module.Name))
                return BadRequest("Invalid Id or model");
            int moduleId = await _modulesServices.AddNewAsync(module,courseId);
            if (moduleId == -1)
                return StatusCode(500, new { error = "Something went wrong" });
            return CreatedAtRoute($"Courses/{courseId}/add-module",moduleId);
        }

        //[Authorize("Teacher")]
        [HttpPost("{courseId}/{moduleId}/add-lesson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> AddNewLessonAsync(LessonDTO lesson,IFormFile video,int courseId,int moduleId)
        {
            if (courseId < 1 || moduleId < 1)
                return BadRequest("Invalid course or module Id");
            int lessonId = await _lessonsServices.AddNewAsync(lesson,courseId,moduleId);
            if(lessonId == -1)
                return StatusCode(500, new { error = "Something went wrong" });
            string url = await _videoServices.UploadVideoToDatabase(video, courseId, moduleId, lessonId);
            if(string.IsNullOrEmpty(url))
                return StatusCode(500, new { error = "Something went wrong" });
            return CreatedAtRoute($"{courseId}/{moduleId}/add-lesson",lessonId);
        }

        //[Authorize("Teacher")]
        [HttpPost("{courseId}/{moduleId}/add-quiz")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreatQuizeAsync(QuizeDTO quize,int courseId,int moduleId)
        {
            if (courseId < 1 || moduleId < 1)
                return BadRequest("Invalid course or module Id");
            int quizeId = await _quizeServices.AddNewAsync(quize,courseId,moduleId);
            if(quizeId == -1)
                return StatusCode(500, new { error = "Something went wrong" });
            return CreatedAtRoute($"{courseId}/{moduleId}/add-quiz", quizeId);
        }

        #endregion

    }
}
