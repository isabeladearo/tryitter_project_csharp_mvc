using System;
namespace Tryitter.Models.DTOs.PostDTO
{
    public class PostDTOStudent
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Guid StudentId { get; set; }
    }
}
