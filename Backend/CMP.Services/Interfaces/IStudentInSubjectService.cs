using CMP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Interfaces
{
    public interface IStudentInSubjectService
    {
        Task<StudentInSubject> CreateStudentInSubject(StudentInSubject studentInSubject);
        Task<StudentInSubject> UpdateStudentInSubject(StudentInSubject studentInSubject);
        Task<IEnumerable<StudentInSubject>> GetAllBySubjectId(int subjectId);
        Task<List<StudentInSubject>> GetAllByStudentId(int studentId);
        Task<StudentInSubject> GetExisitingGradeBySubAndStdId(int subjectId, int studentId);
        Task<int> DeleteStudentInSubject(StudentInSubject studentInSubject);
    }
}
