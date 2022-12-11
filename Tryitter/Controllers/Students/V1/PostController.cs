using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;
using Tryitter.Data.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tryitter.Controllers.Students.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{v:apiVersion}/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository) => _repository = repository;

        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _repository.GetAll().ToList();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var post = _repository.GetById(new Guid(id));
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PostCreate post)
        {
            var postCreated = _repository.Create(post);
            return Created($"v1/posts/{post.Id}", postCreated);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PostCreate post, [FromRoute] string id)
        {
            var postUpdated = _repository.Update(post, new Guid(id));
            return Ok(postUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] string id)
        {
            _repository.Remove(new Guid(id));
            return Ok(new { message = "Post removed with success." });
        }
    }
}
