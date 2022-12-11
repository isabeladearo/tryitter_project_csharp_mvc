using System;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Models.DTOs.PostDTO;

namespace Tryitter.Data.Repository.Interfaces
{
    public interface IPostRepository
    {
        IList<PostDTO> GetAll();
        PostDTO GetById(Guid id);
        PostDTOStudent Create(PostDTOCreate post);
        PostDTOStudent Update(PostDTOUpdate post, Guid id);
        void Remove(Guid id);
    }
}
