using System;
using FluentValidation;
using WebApi.Models.DTOs.StudentDTO;

namespace WebApi.Validators.Student
{
    public class StudentDTOCreateValidator : AbstractValidator<StudentDTOCreate>
    {
        public StudentDTOCreateValidator()
        {
            RuleFor(student => student.Name).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(student => student.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(student => student.Password).NotNull().NotEmpty().MinimumLength(8);
            RuleFor(student => student.Module).NotNull().IsInEnum();
        }
    }
}
