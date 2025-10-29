using As_SVS.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageServices _imageServices;

        public ImageController(IImageServices imageServices)
        {
            _imageServices = imageServices;
        }

        [HttpPost("Upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadImageAsync(IFormFile imageFile,string userId)
        {
            if (imageFile is null || imageFile.Length is 0)
                return BadRequest("No File uploaded");

            var path = await _imageServices.UploadImageAsync(imageFile,userId);

            if (string.IsNullOrEmpty(path))
                return BadRequest("Something went wrong");
            return Ok(path);
        }

    }
}
