using System;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;

namespace Tryitter.Data.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IList<StudentDTO> GetAll();
        //StudentDTO GetById(Guid id);
        //StudentDTO Create(StudentCreate student);
        //StudentDTO Update(StudentCreate student, Guid id);
        //OkObjectResult Remove(Guid id);
    }
}

