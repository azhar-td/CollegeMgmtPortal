using CMP.Data.Models;
using CMP.Data.Repository.Interfaces;
using CMP.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Data.UnitOfWork.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CMPContext _context;
        public ICourseRepo Courses { get; }
        public ICourseDetailRepo CourseDetails { get; }
        public IStudentInSubjectRepo StudentInSubjects { get; }
        public IStudentRepo Students { get; }
        public IAssignedStudentRepo AssignedStudents { get; }
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
