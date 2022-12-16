using System;
using FluentValidation;
using WebApi.Models.DTOs.PostDTO;

namespace WebApi.Validators.Post
{
    public class PostDTOUpdateValidator : AbstractValidator<PostDTOUpdate>
    {
        public PostDTOUpdateValidator()
        {
            RuleFor(post => post.Title).NotNull().NotEmpty().MaximumLength(70);
            RuleFor(post => post.Body).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(post => post.Image).NotNull().NotEmpty().MaximumLength(2048);
        }
    }
}
