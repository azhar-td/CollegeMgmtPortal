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
    public class SubjectService : ISubjectService
    {
        IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Subject> CreateSubject(Subject subject)
        {
            _unitOfWork.Subjects.Create(subject);
            await _unitOfWork.Complete();
            return subject;
        }

        public async Task<int> DeleteSubject(Subject subject)
        {
            _unitOfWork.Subjects.Delete(subject);
            return await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _unitOfWork.Subjects
            .FindAll()
            .Include(a => a.StudentInSubjects)
            .ThenInclude(a => a.Student)
            .ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int subjectId)
        {
            return await _unitOfWork.Subjects
               .FindByCondition(a => a.Id == subjectId)
               .Include(a => a.StudentInSubjects)
               .ThenInclude(a => a.Student)
               .FirstOrDefaultAsync();
        }

        public async Task<Subject> GetSubjectByName(string subjectName)
        {
            return await _unitOfWork.Subjects
               .FindByCondition(a => a.Name == subjectName)
               .Include(a => a.StudentInSubjects)
               .ThenInclude(a => a.Student)
               .FirstOrDefaultAsync();
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            _unitOfWork.Subjects.Delete(subject);
            await _unitOfWork.Complete();
            return subject;
        }
    }
}
