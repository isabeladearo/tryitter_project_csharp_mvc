using System;
namespace Tryitter.Models.DTOs.StudentDTO
{
    public class StudentDTOToken
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}

