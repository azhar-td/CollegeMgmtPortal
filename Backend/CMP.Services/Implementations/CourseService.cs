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
    public class CourseService : ICourseService
    {
        IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            _unitOfWork.Courses.Create(course);
            await _unitOfWork.Complete();
            return course;
        }

        public async Task<int> DeleteCourse(Course course)
        {
            _unitOfWork.Courses.Delete(course);
            return await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _unitOfWork.Courses
                .FindAll()
                .Include(a => a.CourseDetails)
                .Include(a => a.AssignedStudents)
                .ThenInclude(a => a.Student)
                .ToListAsync();
        }

        public async Task<Course> GetCourseById(int courseId)
        {
            return await _unitOfWork.Courses
                .FindByCondition(a => a.Id == courseId)
                .Include(a => a.CourseDetails)
                .Include(a => a.AssignedStudents)
                .ThenInclude(a => a.Student)
                .FirstOrDefaultAsync();
        }

        public async Task<Course> GetCourseByName(string courseName)
        {
            return await _unitOfWork.Courses
                .FindByCondition(a => a.Name.ToLower() == courseName.ToLower())
                .Include(a => a.CourseDetails)
                .Include(a => a.AssignedStudents)
                .ThenInclude(a => a.Student)
                .FirstOrDefaultAsync();
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _unitOfWork.Courses
                .Update(course);
            await _unitOfWork.Complete();
            return course;
        }
    }
}
