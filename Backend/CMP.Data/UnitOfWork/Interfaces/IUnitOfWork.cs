using CMP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Data.UnitOfWork.Interfaces
{
    internal interface IUnitOfWork:IDisposable
    {
        ICourseRepo Courses { get; }
        IStudentInCourseRepo StudentInCourses { get; }
        IStudentInSubjectRepo StudentInSubjects { get; }
        IStudentRepo Students { get; }
        ISubjectInCourseRepo SubjectsInCourse { get; }
        ISubjectRepo Subjects { get; }
        ITeacherRepo Teachers { get; }
        Task<int> Complete();
    }
}
