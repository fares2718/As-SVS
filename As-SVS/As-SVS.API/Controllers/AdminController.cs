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

        #region OnPerson

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

        [HttpGet("{Id}", Name = "GetPersonById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPersonByIdAsync(int Id)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} is not valid");
            var person = await _personSevices.GetByIdAsync(Id);
            if (person == null) 
                return NotFound($"Person with ID {Id} dose not exist");
            return Ok(person);
        }

        [HttpPut("Update-Person/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePersonAsync(int Id, PersonDTO personDTO)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} is not valid");
            var person = await _personSevices.GetByIdAsync(Id);
            if (person == null)
                return NotFound($"Person with ID {Id} dose not exist");
            personDTO.Id = person.Id;
            person.FirstName = personDTO.FirstName;
            person.MiddleName = personDTO.MiddleName;
            personDTO.LastName = personDTO.LastName;
            person.Password = personDTO.Password;
            person.Phone = personDTO.Phone;
            if(await _personSevices.UpdateAsync(person))
                return Ok(person);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update person");
        }

        [HttpDelete("Delete-Person/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePersonAsync(int Id)
        {
            if (Id < 1)
                return BadRequest($"ID {Id} is not valid");
            var person = await _personSevices.GetByIdAsync(Id);
            if (person == null)
                return NotFound($"Person with ID {Id} dose not exist");
            if (await _personSevices.DeleteAsync(Id))
                return Ok(person);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete person");
        }

        [HttpGet("Filter-People-By-Name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterPeopleByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Name Is requiered");
            var peopleList = await _personSevices.FilterByName(name);
            if (peopleList.Count() == 0)
                return NotFound($"No person with name {name} was found");
            return Ok(peopleList);
        }

        [HttpGet("Filter-People-By-DOB/{DOB}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FiltePeopleByDOB(DateOnly DOB)
        {
            var peopleList = await _personSevices.FilterByDOB(DOB);
            if (peopleList.Count() == 0)
                return NotFound($"No person with DOB {DOB.ToString()} was found");
            return Ok(peopleList);
        }

        [HttpGet("Filter-People-By-Gender/{gender}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FiltePeopleByGender(string gender)
        {
            if (gender != "Male".ToLower() || gender != "Female".ToLower())
                return BadRequest("gender is either Male or Female");
            var peopleList = new List<PersonDTO>();
            switch (gender)
            {
                case "Male":
                    peopleList = (List<PersonDTO>)await _personSevices.FilterByGender(false);
                    break;
                case "Female":
                    peopleList = (List<PersonDTO>)await _personSevices.FilterByGender(true);
                    break;
            }
            if (peopleList.Count == 0)
                return NotFound("No person was found");
            return Ok(peopleList);
        }
        #endregion
    }
}
