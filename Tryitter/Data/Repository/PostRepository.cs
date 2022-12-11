using System;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;
using Tryitter.Data.Repository.Interfaces;

namespace Tryitter.Data
{
    public class PostRepository : IPostRepository
    {
        public IList<PostDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public PostDTO GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public PostDTO Create(PostCreate post)
        {
            throw new NotImplementedException();
        }

        public PostDTO Update(PostCreate post, Guid id)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult Remove(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}

