using System;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tryitter.Models.Enums;

namespace Tryitter.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Module Module { get; set; }
        public bool Status { get; set; }
        public IList<Post> Posts { get; set; }
    }

    public class StudentDTO
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Module Module { get; set; }
        public bool Status { get; set; }
        public IList<PostDTO> Posts { get; set; }
    }

    public class StudentCreate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Module Module { get; set; }
        public bool Status { get; set; }
    }
}

