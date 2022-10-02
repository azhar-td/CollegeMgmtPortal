using CMP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> CreateTeacher(Teacher teacher);
        Task<Teacher> UpdateTeacher(Teacher teacher);
        Task<int> DeleteTeacher(Teacher teacher);
        Task<Teacher> GetTeacherById(int teacherId);
        Task<Teacher> GetTeacherByName(string teacherName);
        Task<IEnumerable<Teacher>> GetAllTeachers();

        Task<IEnumerable<Teacher>> GetAllUnAssignedTeachersByCourseId(int courseId);
    }
}
