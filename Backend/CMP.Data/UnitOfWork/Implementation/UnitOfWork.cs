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
        public UnitOfWork(CMPContext cMPContext, 
            ICourseRepo courseRepo, 
            ICourseDetailRepo courseDetailRepo,
            IStudentInSubjectRepo studentInSubjectRepo,
            IStudentRepo studentRepo,
            IAssignedStudentRepo assignedStudentRepo,
            ISubjectRepo subjectRepo,
            ITeacherRepo teacherRepo)
        {
            this._context = cMPContext;
            this.Courses = courseRepo;
            this.CourseDetails = courseDetailRepo;
            this.StudentInSubjects = studentInSubjectRepo;
            this.Students = studentRepo;
            this.AssignedStudents = assignedStudentRepo;
            this.Subjects = subjectRepo;
            this.Teachers = teacherRepo;
        }
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
