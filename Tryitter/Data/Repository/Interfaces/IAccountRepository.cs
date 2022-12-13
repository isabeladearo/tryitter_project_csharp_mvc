using System;
using Tryitter.Models;
using Tryitter.Models.DTOs.StudentDTO;

namespace Tryitter.Data.Repository.Interfaces
{
    public interface IAccountRepository
    {
        string Login(StudentDTOLogin student);
        StudentDTOToken CreateAccount(StudentDTOCreate student);
    }
}
