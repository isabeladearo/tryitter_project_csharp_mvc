using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Data.Repository.Interfaces;
using Tryitter.Models.DTOs.PostDTO;

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
            var posts = _repository.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var post = _repository.GetById(new Guid(id));
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PostDTOCreate post)
        {
            var postCreated = _repository.Create(post);
            return Created($"api/v1/posts/{postCreated.PostId}", postCreated);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PostDTOUpdate post, [FromRoute] string id)
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
