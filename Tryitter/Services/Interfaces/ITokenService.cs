using System;
using Tryitter.Models;
using Tryitter.Models.DTOs.StudentDTO;

namespace Tryitter.Services
{
    public interface ITokenService
    {
        string GenerateToken(Student student);
    }
}
