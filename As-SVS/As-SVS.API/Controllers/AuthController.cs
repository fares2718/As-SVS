using As_SVS.Business.Interfaces;
using As_SVS.Core.Models;
using As_SVS.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCypt = BCrypt.Net.BCrypt;



namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IPersonSevices _services;
        public AuthController(IPersonSevices services)
        {
            _services = services;
        }

        [HttpPost("register-Person")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterPerson(PersonDTO personDTO)
        {
            var existing = await _services.GetPersonByEmailAsync(personDTO.Email);
            if (existing != null)
                return BadRequest("Person alredy exists");

            var person = new PersonDTO
            {
                Email = personDTO.Email,
                FirstName = personDTO.FirstName,
                MiddleName = personDTO.MiddleName,
                LastName = personDTO.LastName,
                Gender = personDTO.Gender,
                Password = BCrypt.Net.BCrypt.HashPassword(personDTO.Password),
                DateOfBirth = personDTO.DateOfBirth,
                Id = personDTO.Id,
                ImageUrl = personDTO.ImageUrl,
                Permission = PersonDTO.Permissions.None,
                Phone = personDTO.Phone,
            };

            await _services.AddNewAsync(personDTO);
            return Ok(person);
        }

        [HttpPost("LogIn")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> LogIn(LogInDTO logInDTO)
        {
            var person = await _services.GetPersonByEmailAsync(logInDTO.Email);
            if (person == null)
                return Unauthorized("Invalid email.");
            bool valid = BCrypt.Net.BCrypt.Verify(logInDTO.Password, person.Password);
            if (!valid)
                return Unauthorized("Invalid password.");
            return Ok(person);
        }
    }
}
