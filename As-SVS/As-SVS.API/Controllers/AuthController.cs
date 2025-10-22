using As_SVS.Business.Interfaces;
using As_SVS.Core.Models;
using As_SVS.API.Helpers;
using As_SVS.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCypt = BCrypt.Net.BCrypt;



namespace As_SVS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonSevices _services;
        public AuthController(IPersonSevices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost("register-Person")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterPerson(PersonDTO personDTO)
        {
            var existing = await _services.GetPersonByEmailAsync(personDTO.Email);
            if (existing != null)
                return BadRequest("Person alredy exists");
             Person person = _mapper.Map<Person>(personDTO);
            int Id = await _services.AddNewAsync(person);
            return Ok(Id);
        }

        [HttpPost("LogIn")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> LogIn(LogInDTO logInDTO)
        {
            var person = await _services.GetPersonByEmailAsync(logInDTO.Email);
            var personDTO = _mapper.Map<PersonDTO>(person);
            if (personDTO == null)
                return Unauthorized("Invalid email.");
            bool valid = As_SVS.API.Helpers.Cryptography.Verify(logInDTO.Password,personDTO.Password);
            if (!valid)
                return Unauthorized("Invalid password.");
            return Ok(personDTO);
        }
    }
}
