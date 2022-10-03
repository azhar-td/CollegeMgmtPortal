using CMP.Data.Models;
using CMP.Data.UnitOfWork.Interfaces;
using CMP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Implementations
{
    public class StudentInSubjectService : IStudentInSubjectService
    {
        IUnitOfWork _unitOfWork;

        public StudentInSubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StudentInSubject> CreateStudentInSubject(StudentInSubject studentInSubject)
        {
            _unitOfWork.StudentInSubjects.Create(studentInSubject);
            await _unitOfWork.Complete();
            return studentInSubject;
        }

        public async Task<int> DeleteStudentInSubject(StudentInSubject studentInSubject)
        {
            _unitOfWork.StudentInSubjects.Delete(studentInSubject);
            return await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<StudentInSubject>> GetAllBySubjectId(int subjectId)
        {
            return await _unitOfWork.StudentInSubjects
                    .FindByCondition(a => a.SubjectId == subjectId)
                    .Include(a => a.Student)
                    .ToListAsync();
        }

        public async Task<List<StudentInSubject>> GetAllByStudentId(int studentId)
        {
            return await _unitOfWork.StudentInSubjects
                .FindByCondition(a => a.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<StudentInSubject> UpdateStudentInSubject(StudentInSubject studentInSubject)
        {
            _unitOfWork.StudentInSubjects.Update(studentInSubject);
            await _unitOfWork.Complete();
            return studentInSubject;
        }

        public async Task<StudentInSubject> GetExisitingGradeBySubAndStdId(int subjectId, int studentId)
        {
            return await _unitOfWork.StudentInSubjects
                .FindByCondition(a => a.SubjectId == subjectId && a.StudentId == studentId)
                .FirstOrDefaultAsync();
        }
    }
}
