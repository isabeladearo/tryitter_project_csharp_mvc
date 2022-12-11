using System;
namespace Tryitter.Models.DTOs.PostDTO
{
    public class PostDTOCreate
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public Guid StudentId { get; set; }
    }
}
