using System;
using FluentValidation;
using WebApi.Models.DTOs.PostDTO;

namespace WebApi.Validators.Post
{
    public class PostDTOCreateValidator : AbstractValidator<PostDTOCreate>
    {
        public PostDTOCreateValidator()
        {
            RuleFor(post => post.Title).NotNull().NotEmpty().MaximumLength(70);
            RuleFor(post => post.Body).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(post => post.Image).NotNull().NotEmpty().MaximumLength(2048);
            RuleFor(post => post.StudentId).NotNull().NotEmpty().Must(ValidateId);
        }

        private bool ValidateId(string id)
        {
            return Guid.TryParse(id, out var result);
        }
    }
}
