using System;
using WebApi.Models.Enums;

namespace WebApi.Models.DTOs.StudentDTO
{
    public class StudentDTOUpdate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Module Module { get; set; }
        public bool Status { get; set; }
    }
}

