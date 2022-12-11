using System;
using Tryitter.Models.Enums;

namespace Tryitter.Models.DTOs.StudentDTO
{
    public class StudentDTOCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Module Module { get; set; }
    }
}
