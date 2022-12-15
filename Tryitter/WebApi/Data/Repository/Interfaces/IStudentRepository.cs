using System;
using WebApi.Models.DTOs.StudentDTO;

namespace WebApi.Data.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IList<StudentDTO> GetAll();
        StudentDTO GetById(Guid id);
        StudentDTO GetByName(string studentName);
        StudentDTOName Update(StudentDTOUpdate student, Guid id);
        void Remove(Guid id);
    }
}

