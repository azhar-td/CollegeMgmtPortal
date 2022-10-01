using CMP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<Subject> CreateSubject(Subject subject);
        Task<Subject> UpdateSubject(Subject subject);
        Task<int> DeleteSubject(Subject subject);
        Task<Subject> GetSubjectById(int subjectId);
        Task<Subject> GetSubjectByName(string subjectName);
        Task<IEnumerable<Subject>> GetAllSubjects();
    }
}
