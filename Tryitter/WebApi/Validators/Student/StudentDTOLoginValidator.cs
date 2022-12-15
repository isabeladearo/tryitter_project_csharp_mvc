using System;
using FluentValidation;
using WebApi.Models.DTOs.StudentDTO;

namespace WebApi.Validators
{
    public class StudentDTOLoginValidator : AbstractValidator<StudentDTOLogin>
    {
        public StudentDTOLoginValidator()
        {
            RuleFor(student => student.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(student => student.Password).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}
