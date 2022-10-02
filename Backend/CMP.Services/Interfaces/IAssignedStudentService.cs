using CMP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Interfaces
{
    public interface IAssignedStudentService
    {
        Task<AssignedStudent> CreateAssignedStudent(AssignedStudent assignedStudent);
        Task<AssignedStudent> UpdateAssignedStudent(AssignedStudent assignedStudent);
        Task<IEnumerable<AssignedStudent>> GetAllByCourseId(int courseId);
        Task<int> DeleteAssignedStudent(AssignedStudent assignedStudent);
    }
}
