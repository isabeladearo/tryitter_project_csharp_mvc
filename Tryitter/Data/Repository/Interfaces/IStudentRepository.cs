using System;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;
using Tryitter.Models.DTOs.StudentDTO;

namespace Tryitter.Data.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IList<StudentDTO> GetAll();
        StudentDTO GetById(Guid id);
        StudentDTOName Create(StudentDTOCreate student);
        StudentDTOName Update(StudentDTOUpdate student, Guid id);
        void Remove(Guid id);
    }
}

