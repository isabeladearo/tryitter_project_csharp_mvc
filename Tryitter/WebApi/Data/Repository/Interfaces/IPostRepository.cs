using WebApi.Models.DTOs.PostDTO;

namespace WebApi.Data.Repository.Interfaces
{
    public interface IPostRepository
    {
        IList<PostDTO> GetAll();
        PostDTO GetById(Guid id);
        PostDTO GetLastPost();
        PostDTOStudent Create(PostDTOCreate post);
        PostDTOStudent Update(PostDTOUpdate post, Guid id);
        void Remove(Guid id);
    }
}
