using CMP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepo Courses { get; }
        ICourseDetailRepo CourseDetails { get; }
        IStudentInSubjectRepo StudentInSubjects { get; }
        IStudentRepo Students { get; }
        IAssignedStudentRepo AssignedStudents { get; }
        ISubjectRepo Subjects { get; }
        ITeacherRepo Teachers { get; }
        Task<int> Complete();
    }
}
