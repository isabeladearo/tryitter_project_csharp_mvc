using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Data.Repository.Interfaces;
using Tryitter.Models;
using Tryitter.Models.DTOs.PostDTO;
using Tryitter.Models.DTOs.StudentDTO;
using Tryitter.Services;

namespace Tryitter.Data
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly TryitterContext _context;
        protected readonly ITokenService _tokenService;

        public StudentRepository(TryitterContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public IList<StudentDTO> GetAll()
        {
            var students = _context
                .Students
                .AsNoTracking()
                .Include(x => x.Posts)
                .Select(s => new StudentDTO
                {
                    StudentId = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Module = s.Module,
                    Status = s.Status,
                    Posts = s.Posts.Select(p => new PostDTO
                    {
                        PostId = p.Id,
                        Title = p.Title,
                        Body = p.Body,
                        Image = p.Image,
                    }).ToList()
                })
                .ToList();

            return students;
        }

        public StudentDTO GetById(Guid id)
        {
            var studentFound = _context
                .Students
                .AsNoTracking()
                .Include(s => s.Posts)
                .Select(s => new StudentDTO
                {
                    StudentId = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Module = s.Module,
                    Status = s.Status,
                    Posts = s.Posts.Select(p => new PostDTO
                    {
                        PostId = p.Id,
                        Title = p.Title,
                        Body = p.Body,
                        Image = p.Image,
                    }).ToList()
                })
                .FirstOrDefault(s => s.StudentId == id);

            return studentFound;
        }

        public StudentDTOName Create(StudentDTOCreate student)
        {
            var studentInstance = new Student
            {
                Id = new Guid(),
                Name = student.Name,
                Email = student.Email,
                PasswordHash = student.Password,
                Module = student.Module,
                Status = true,
            };

            _context.Students.Add(studentInstance);
            _context.SaveChanges();

            return new StudentDTOName { StudentId = studentInstance.Id, Name = studentInstance.Name };
        }

        public StudentDTOName Update(StudentDTOUpdate student, Guid id)
        {
            var studentFound = _context.Students.FirstOrDefault(s => s.Id == id);

            if (studentFound != null)
            {
                studentFound.Name = student.Name;
                studentFound.Email = student.Email;
                studentFound.PasswordHash = student.Password;
                studentFound.Module = student.Module;
                studentFound.Status = student.Status;

                _context.Students.Update(studentFound);
                _context.SaveChanges();
            }

            return new StudentDTOName { StudentId = studentFound.Id, Name = studentFound.Name };
        }

        public void Remove(Guid id)
        {
            var studentFound = _context.Students.FirstOrDefault(s => s.Id == id);

            if (studentFound != null)
            {
                _context.Students.Remove(studentFound);
                _context.SaveChanges();
            }
        }

        public string Login(StudentDTOLogin student)
        {
            var studentFound = _context.Students.AsNoTracking().FirstOrDefault(s => s.Email == student.Email);

            if (studentFound.PasswordHash != student.Password)
            {
                return null;
            }

            var studentLogin = new StudentDTOLogin
            {
                Email = studentFound.Email,
                Password = studentFound.PasswordHash,
            };

            var token = _tokenService.GerarToken(Configuration.JwtKey, studentLogin);

            return token;
        }
    }
}
