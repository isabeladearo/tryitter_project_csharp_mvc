using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;
using Tryitter.Data.Repository.Interfaces;
using Tryitter.Models.DTOs.StudentDTO;

namespace Tryitter.Controllers.Students.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository) => _repository = repository;

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _repository.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var student = _repository.GetById(new Guid(id));
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentDTOCreate student)
        {
            var studentCreated = _repository.Create(student);
            return Created($"api/v1/students/{studentCreated.StudentId}", studentCreated);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] StudentDTOUpdate student, [FromRoute] string id)
        {
            var studentUpdated = _repository.Update(student, new Guid(id));
            return Ok(studentUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] string id)
        {
            _repository.Remove(new Guid(id));
            return Ok(new { message = "Student removed with success." });
        }

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
    }
}
