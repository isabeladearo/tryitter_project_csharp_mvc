using System;
using Tryitter.Models.Enums;

namespace Tryitter.Models.DTOs.StudentDTO
{
    public class StudentDTO
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Module Module { get; set; }
        public bool Status { get; set; }
        public IList<PostDTO.PostDTO> Posts { get; set; }
    }
}

