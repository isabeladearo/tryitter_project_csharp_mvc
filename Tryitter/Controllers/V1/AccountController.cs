using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Data.Repository.Interfaces;
using Tryitter.Models;
using Tryitter.Models.DTOs.StudentDTO;

namespace Tryitter.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;

        public AccountController(IAccountRepository repository) => _repository = repository;

        [HttpPost("login")]
        public IActionResult Login([FromBody] StudentDTOLogin student)
        {
            var token = _repository.Login(student);

            if (token == null)
            {
                return BadRequest("Email ou senha inválidos");
            }

            return Ok(new { message = token });
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] StudentDTOCreate student)
        {
            var studentCreated = _repository.CreateAccount(student);
            return Created($"api/v1/students/{studentCreated.StudentId}", studentCreated);
        }

        [HttpGet]
        public IActionResult GetStudent() => Ok();
    }
}

