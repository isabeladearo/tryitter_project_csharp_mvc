using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Data.Repository.Interfaces;
using Tryitter.Models;
using Tryitter.Models.DTOs.PostDTO;
using Tryitter.Models.DTOs.StudentDTO;
using Tryitter.Services;
using System.Security.Claims;

namespace Tryitter.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TryitterContext _context;

        public StudentRepository(TryitterContext context) => _context = context;

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

        public StudentDTOName Update(StudentDTOUpdate student, Guid id)
        {
            var studentFound = _context.Students.FirstOrDefault(s => s.Id == id);

            if (studentFound != null)
            {
                studentFound.Name = student.Name;
                studentFound.Email = student.Email;
                studentFound.Password = student.Password;
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
    }
}
