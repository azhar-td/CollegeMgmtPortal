using CMP.Data.Repository.Interfaces;
using CMP.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Data.UnitOfWork.Implementation
{
    internal class UnitOfWork:IUnitOfWork
    {
        public ICourseRepo Courses { get; }
        public IStudentInCourseRepo StudentInCourses { get; }
        public IStudentInSubjectRepo StudentInSubjects { get; }
        public IStudentRepo Students { get; }
        public ISubjectInCourseRepo SubjectsInCourse { get; }
        public ISubjectRepo Subjects { get; }
        public ITeacherRepo Teachers { get; }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
