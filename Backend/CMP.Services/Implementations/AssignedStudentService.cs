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
    public class AssignedStudentService : IAssignedStudentService
    {
        IUnitOfWork _unitOfWork;

        public AssignedStudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AssignedStudent> CreateAssignedStudent(AssignedStudent assignedStudent)
        {
            _unitOfWork.AssignedStudents.Create(assignedStudent);
            await _unitOfWork.Complete();
            return assignedStudent;
        }

        public async Task<int> DeleteAssignedStudent(AssignedStudent assignedStudent)
        {
            _unitOfWork.AssignedStudents.Delete(assignedStudent);
            return await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<AssignedStudent>> GetAllByCourseId(int courseId)
        {
            return await _unitOfWork.AssignedStudents
                    .FindByCondition(a => a.CourseId == courseId)
                    .Include(a => a.Course)
                    .Include(a => a.Student)
                    .ToListAsync();
        }

        public async Task<AssignedStudent> UpdateAssignedStudent(AssignedStudent assignedStudent)
        {
            _unitOfWork.AssignedStudents
                    .Update(assignedStudent);
            await _unitOfWork.Complete();
            return assignedStudent;
        }

        public async Task<AssignedStudent> GetByStudentId(int studentId)
        {
            return await _unitOfWork.AssignedStudents
                .FindByCondition(a => a.StudentId == studentId)
                .FirstOrDefaultAsync();
        }
    }
}
