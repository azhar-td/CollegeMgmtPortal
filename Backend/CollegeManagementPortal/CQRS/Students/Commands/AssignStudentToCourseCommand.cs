using AutoMapper;
using CMP.Data.Models;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Students.Commands
{
    public class AssignStudentToCourseCommand : IRequest<DTO_AssignedStudent>
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public class AssignStudentToCourseCommandHandler : IRequestHandler<AssignStudentToCourseCommand, DTO_AssignedStudent>
        {
            private IMapper _mapper;
            private IAssignedStudentService _assignedStudentService;
            public AssignStudentToCourseCommandHandler(IMapper mapper, IAssignedStudentService assignedStudentService)
            {
                _mapper = mapper;
                _assignedStudentService = assignedStudentService;
            }

            public async Task<DTO_AssignedStudent> Handle(AssignStudentToCourseCommand command, CancellationToken cancellationToken)
            {
                var assignedStudent = new AssignedStudent();
                assignedStudent.CourseId = command.CourseId;
                assignedStudent.StudentId = command.StudentId;
                assignedStudent.AvgGrade = 0;
                assignedStudent.CreatedAt = DateTime.Now;
                assignedStudent.UpdatedAt = DateTime.Now;

                await _assignedStudentService.CreateAssignedStudent(assignedStudent);

                return _mapper.Map<DTO_AssignedStudent>(assignedStudent);
            }
        }
    }
}
