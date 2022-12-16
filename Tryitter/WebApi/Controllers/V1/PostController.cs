using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Repository.Interfaces;
using WebApi.Models.DTOs.PostDTO;
using WebApi.Services;
using WebApi.Validators;
using WebApi.Validators.Post;

namespace WebApi.Controllers.Students.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{v:apiVersion}/posts")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var postById = _repository.GetById(id);
            return Ok(postById);
        }

        [HttpGet("last")]
        public IActionResult GetLastPost()
        {
            var post = _repository.GetLastPost();
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PostDTOCreate post)
        {
            PostDTOCreateValidator _validator = new();
            var result = _validator.Validate(post);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var postCreated = _repository.Create(post);
            return Created($"api/v1/posts/{postCreated.PostId}", postCreated);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PostDTOUpdate post, [FromRoute] string id)
        {
            PostDTOUpdateValidator _validator = new();
            var result = _validator.Validate(post);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

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
