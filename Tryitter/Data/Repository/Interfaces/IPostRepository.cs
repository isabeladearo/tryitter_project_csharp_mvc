using System;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;

namespace Tryitter.Data.Repository.Interfaces
{
    public interface IPostRepository
    {
        IList<PostDTO> GetAll();
        PostDTO GetById(Guid id);
        PostDTO Create(PostCreate post);
        PostDTO Update(PostCreate post, Guid id);
        OkObjectResult Remove(Guid id);
    }
}
