using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Models;
using Tryitter.Data.Repository.Interfaces;

namespace Tryitter.Data
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly TryitterContext _context;

        public StudentRepository(TryitterContext context) => _context = context;

        public IList<StudentDTO> GetAll()
        {
            var students = _context
                .Students
                .AsNoTracking()
                .Include(x => x.Posts)
                .Select(a => new StudentDTO
                {
                    StudentId = a.Id,
                    Name = a.Name,
                    Email = a.Email,
                    Module = a.Module,
                    Status = a.Status,
                    Posts = a.Posts.Select(b => new PostDTO
                    {
                        PostId = b.Id,
                        Title = b.Title,
                        Body = b.Body,
                        Image = b.Image,
                    }).ToList()

                })
                .ToList();
            return students;
        }

        //public StudentDTO GetById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public StudentDTO Create(StudentCreate student)
        //{
        //    throw new NotImplementedException();
        //}

        //public StudentDTO Update(StudentCreate student, Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public OkObjectResult Remove(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}

