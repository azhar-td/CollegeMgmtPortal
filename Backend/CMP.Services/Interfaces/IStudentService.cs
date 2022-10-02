using CMP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<int> DeleteStudent(Student student);
        Task<Student> GetStudentById(int studentId);
        Task<Student> GetStudentByName(string studentName);
        Task<Student> GetStudentByRegNum(string regNum);
        Task<string> GetLastRegistrationNum();
        Task<string> GetNewRegistrationNum();
        Task<IEnumerable<Student>> GetAllStudents();
    }
}
