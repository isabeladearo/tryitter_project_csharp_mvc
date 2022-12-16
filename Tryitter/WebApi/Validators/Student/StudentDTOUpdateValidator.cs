using System;
using FluentValidation;
using WebApi.Models.DTOs.StudentDTO;

namespace WebApi.Validators.Student
{
    public class StudentDTOUpdateValidator : AbstractValidator<StudentDTOUpdate>
    {
        public StudentDTOUpdateValidator()
        {
            RuleFor(student => student.Name).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(student => student.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(student => student.Password).NotNull().NotEmpty().MinimumLength(8);
            RuleFor(student => student.Module).NotNull().IsInEnum();
            RuleFor(student => student.Status).Must(option => option == false || option == true);
        }
    }
}
