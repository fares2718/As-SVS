using As_SVS.Business.Interfaces;
using As_SVS.Business.Services;
using As_SVS.Core.Interfaces;
using As_SVS.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IPersonSevices _personSevices;
        private readonly IAdminServices _adminServices;
        public AdminController(IPersonSevices personSevices,IAdminServices adminServices)
        {
            _personSevices = personSevices;
            _adminServices = adminServices;
        }

        [HttpGet("GetAll",Name ="GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPeopleAsync()
        {
            var peopleList = await _personSevices.GetAllAsync();
            if (peopleList.Count() == 0)
                return NotFound("No people found");
            return Ok(peopleList);
        }

    }
}
