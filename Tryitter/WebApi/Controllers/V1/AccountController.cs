using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Repository.Interfaces;
using WebApi.Models.DTOs.StudentDTO;
using WebApi.Validators;
using WebApi.Validators.Student;

namespace WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;

        public AccountController(IAccountRepository repository) => _repository = repository;

        [HttpPost("login")]
        public IActionResult Login([FromBody] StudentDTOLogin student)
        {
            StudentDTOLoginValidator _validator = new();
            var result = _validator.Validate(student);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var token = _repository.Login(student);

            if (token == null)
            {
                return BadRequest("Email ou senha inválidos");
            }

            return Ok(new { token = token });
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] StudentDTOCreate student)
        {
            try
            {
                StudentDTOCreateValidator _validator = new();
                var result = _validator.Validate(student);

                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                var studentCreated = _repository.CreateAccount(student);
                return Created($"api/v1/students/{studentCreated.StudentId}", studentCreated);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Email já cadastrado");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}

