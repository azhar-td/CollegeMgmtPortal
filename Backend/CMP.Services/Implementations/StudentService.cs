using CMP.Data.Models;
using CMP.Data.UnitOfWork.Interfaces;
using CMP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .ThenInclude(a => a.Subject)
                .FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentByName(string studentName)
        {
            return await _unitOfWork.Students
                .FindByCondition(a => a.Name == studentName)
                .Include(a => a.StudentInSubjects)
                .ThenInclude(a => a.Subject)
                .FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentByRegNum(string regNum)
        {
            return await _unitOfWork.Students
                .FindByCondition(a => a.RegNum.ToLower() == regNum.ToLower())
                .Include(a => a.StudentInSubjects)
                .ThenInclude(a => a.Subject)
                .FirstOrDefaultAsync();
        }

        public async Task<string> GetLastRegistrationNum()
        {
           var result = await _unitOfWork.Students
                .FindAll()
                .OrderByDescending(a => a.CreatedAt)
                .FirstOrDefaultAsync();
            return result.RegNum;
        }

        public async Task<string> GetNewRegistrationNum()
        {
            var result = await _unitOfWork.Students
                 .FindAll()
                 .OrderByDescending(a => a.CreatedAt)
                 .FirstOrDefaultAsync();
            if (result == null)
            {
                return "R-0001";
            }
            else
            {
                int numPart = 0;
                int.TryParse(result.RegNum.Split('-')[1], out numPart);
                numPart++;
                string newReg = "R-";
                if (numPart < 10)
                    newReg = newReg + "000";
                else if(numPart < 100)
                    newReg = newReg + "00";
                else if(numPart < 1000)
                    newReg = newReg + "0";
                return newReg + numPart.ToString();
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _unitOfWork.Students.Delete(student);
            await _unitOfWork.Complete();
            return student;
        }

        public async Task<IEnumerable<Student>> GetAllUnAssignedStudents()
        {
            var assignedStudents = await _unitOfWork.AssignedStudents
                .FindAll()
                .ToListAsync();
            List<int> assignedStudentsId = new List<int>();
            foreach (var c in assignedStudents)
            {
                assignedStudentsId.Add(c.StudentId);
            }
            var unAssignedStudents = await _unitOfWork.Students
                .FindByCondition(a => !assignedStudentsId.Contains(a.Id))
                .ToListAsync();
            return unAssignedStudents;
        }

        public async Task<IEnumerable<Student>> GetAllAssignedStudentsByCourseId(int courseId)
        {
            var assignedStudents = await _unitOfWork.AssignedStudents
                .FindByCondition(a => a.CourseId == courseId)
                .ToListAsync();
            List<int> assignedStudentsId = new List<int>();
            foreach (var c in assignedStudents)
            {
                assignedStudentsId.Add(c.StudentId);
            }
            var students = await _unitOfWork.Students
                .FindByCondition(a => assignedStudentsId.Contains(a.Id))
                .ToListAsync();
            return students;
        }
    }
}
