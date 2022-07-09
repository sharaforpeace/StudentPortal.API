using StudentPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentPortal.API.Repositories
{
    public interface IStudentRepository
    {
      Task<List<Student>> GetStudentsAsync();

        Task<Student> GetStudentAsync(Guid studentId);
    }
}
