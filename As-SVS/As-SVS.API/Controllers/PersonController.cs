using As_SVS.Business.Interfaces;
using As_SVS.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonSevices _services;
        private readonly PasswordHasher<PersonDTO> _passwordHasher;
        public PersonController(IPersonSevices services, PasswordHasher<PersonDTO> passwordHasher)
        {
            _services = services;
            _passwordHasher = passwordHasher;
        }

        [HttpGet("All", Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<List<PersonDTO>>> GetAll()
        {
            var list = await _services.GetAllAsync();
            List<PersonDTO> peopleList = new List<PersonDTO>(list);
            if (peopleList.Count == 0)
            {
                return NotFound("No people found");
            }
            else
                return Ok(peopleList);

        }

        [HttpGet("{id}", Name = "GetPersonByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonDTO>> GetPersonById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }
            var person = await _services.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound($"Person with id ({id}) does not exist");
            }
            else
                return Ok(person);
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (id < 1)
                return BadRequest($"Not accepted ID {id}");
            if (await _services.DeleteAsync(id))
                return Ok($"Petrson with ID {id} has been deleted");
            else
                return NotFound($"Student with ID {id} not found. no rows deleted!");
        }

        [HttpPost(Name = "AddNewPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonDTO>> AddNewPerson(PersonDTO person)
        {
            if (person == null)
                return BadRequest("Invalid Data");
            
            var newPerson = await _services.AddNewAsync(person);
            person.Id = newPerson.Id;
            return CreatedAtRoute("GetPersonByID", new { id = person.Id }, person);
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonDTO>> UpdatePerson(int id ,PersonDTO newPersonInfo)
        {
            if (newPersonInfo == null || id < 1)
                return BadRequest("Invalid Data");
            var person = await _services.GetByIdAsync(id);
            if (person == null)
                return NotFound("Person does not exist");
            newPersonInfo.Id = id;
            person = newPersonInfo;
            await _services.UpdateAsync(person);
                return Ok(person);
        }
    }
}
