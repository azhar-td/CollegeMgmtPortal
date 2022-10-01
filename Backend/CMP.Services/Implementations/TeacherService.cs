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
    public class TeacherService : ITeacherService
    {
        IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            _unitOfWork.Teachers.Create(teacher);
            await _unitOfWork.Complete();
            return teacher;
        }

        public async Task<int> DeleteTeacher(Teacher teacher)
        {
            _unitOfWork.Teachers.Delete(teacher);
            return await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _unitOfWork.Teachers
            .FindAll()
            .Include(a => a.CourseDetails)
            .ThenInclude(a => a.Subject)
            .ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _unitOfWork.Teachers
               .FindByCondition(a => a.Id == teacherId)
               .Include(a => a.CourseDetails)
               .ThenInclude(a => a.Subject)
               .FirstOrDefaultAsync();
        }

        public async Task<Teacher> GetTeacherByName(string teacherName)
        {
            return await _unitOfWork.Teachers
               .FindByCondition(a => a.Name == teacherName)
               .Include(a => a.CourseDetails)
               .ThenInclude(a => a.Subject)
               .FirstOrDefaultAsync();
        }

        public async Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            _unitOfWork.Teachers.Delete(teacher);
            await _unitOfWork.Complete();
            return teacher;
        }
    }
}
