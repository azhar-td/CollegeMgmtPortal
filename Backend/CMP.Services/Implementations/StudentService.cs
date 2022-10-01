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
    public class StudentService : IStudentService
    {
        IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _unitOfWork.Students.Create(student);
            await _unitOfWork.Complete();
            return student;
        }

        public async Task<int> DeleteStudent(Student student)
        {
            _unitOfWork.Students.Delete(student);
            return await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _unitOfWork.Students
                        .FindAll()
                        .Include(a => a.StudentInSubjects)
                        .ThenInclude(a => a.Subject)
                        .ToListAsync();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _unitOfWork.Students
                .FindByCondition(a => a.Id == studentId)
                .Include(a => a.StudentInSubjects)
                .ThenInclude(a => a.Student)
                .FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentByName(string studentName)
        {
            return await _unitOfWork.Students
                .FindByCondition(a => a.Name == studentName)
                .Include(a => a.StudentInSubjects)
                .ThenInclude(a => a.Student)
                .FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentByRegNum(int regNum)
        {
            return await _unitOfWork.Students
                .FindByCondition(a => a.RegNum == regNum)
                .Include(a => a.StudentInSubjects)
                .ThenInclude(a => a.Student)
                .FirstOrDefaultAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _unitOfWork.Students.Delete(student);
            await _unitOfWork.Complete();
            return student;
        }
    }
}
