using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApi.Models.Enums;

namespace WebApi.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Module Module { get; set; }
        public bool Status { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Post> Posts { get; set; }
    }
}
