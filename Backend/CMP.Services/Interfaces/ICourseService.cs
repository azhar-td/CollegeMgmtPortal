using CMP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<int> DeleteCourse(Course course);
        Task<Course> GetCourseById(int courseId);
        Task<Course> GetCourseByName(string courseName);
        Task<IEnumerable<Course>> GetAllCourses();
    }
}
