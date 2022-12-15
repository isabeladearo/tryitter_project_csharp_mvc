using System;
using WebApi.Models;

namespace WebApi.Services
{
    public interface ITokenService
    {
        string GenerateToken(Student student);
    }
}
