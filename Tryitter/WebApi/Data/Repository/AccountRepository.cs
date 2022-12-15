using Microsoft.EntityFrameworkCore;
using WebApi.Data.Repository.Interfaces;
using WebApi.Models;
using WebApi.Models.DTOs.StudentDTO;
using WebApi.Services;

namespace WebApi.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TryitterContext _context;
        private readonly ITokenService _tokenService;

        public AccountRepository(TryitterContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public string Login(StudentDTOLogin student)
        {
            var studentFound = _context.Students.AsNoTracking().FirstOrDefault(s => s.Email == student.Email);

            if (studentFound.Password != student.Password)
            {
                return null;
            }

            var token = _tokenService.GenerateToken(studentFound);

            return token;
        }

        public StudentDTOToken CreateAccount(StudentDTOCreate student)
        {
            var instance = new Student
            {
                Id = new Guid(),
                Name = student.Name,
                Email = student.Email,
                Password = student.Password,
                Module = student.Module,
                Status = true,
            };

            _context.Students.Add(instance);
            _context.SaveChanges();

            var token = _tokenService.GenerateToken(instance);

            return new StudentDTOToken { StudentId = instance.Id, Name = instance.Name, Token = token };
        }
    }
}
