using WebApi.Models.DTOs.StudentDTO;

namespace WebApi.Data.Repository.Interfaces
{
    public interface IAccountRepository
    {
        string Login(StudentDTOLogin student);
        StudentDTOToken CreateAccount(StudentDTOCreate student);
    }
}
