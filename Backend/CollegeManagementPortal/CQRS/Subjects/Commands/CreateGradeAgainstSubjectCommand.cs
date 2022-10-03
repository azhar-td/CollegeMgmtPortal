using AutoMapper;
using CMP.Data.Models;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Subjects.Commands
{
    public class CreateGradeAgainstSubjectCommand : IRequest<DTO_StudentInSubject>
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [RegularExpression(@"^[1-9][0-9]?$|^100$",
            ErrorMessage = "1 to 100 values allowed")]
        public int Grades { get; set; }

        public class CreateGradeAgainstSubjectCommandHandler : IRequestHandler<CreateGradeAgainstSubjectCommand, DTO_StudentInSubject>
        {
            private IMapper _mapper;
            private IStudentInSubjectService _studentInSubjectService;
            private IAssignedStudentService _assignedStudentService;
            public CreateGradeAgainstSubjectCommandHandler(IMapper mapper, IStudentInSubjectService studentInSubjecttService, IAssignedStudentService assignedStudentService)
            {
                _mapper = mapper;
                _studentInSubjectService = studentInSubjecttService;
                _assignedStudentService = assignedStudentService;
            }

            public async Task<DTO_StudentInSubject> Handle(CreateGradeAgainstSubjectCommand command, CancellationToken cancellationToken)
            {
                //Check if grade already exist for subject
                var existingGrade = await _studentInSubjectService.GetExisitingGradeBySubAndStdId(command.SubjectId, command.StudentId);
                var studentInSubject = new StudentInSubject();

                //Create new grade in the system
                if (existingGrade == null)
                {
                    studentInSubject.SubjectId = command.SubjectId;
                    studentInSubject.StudentId = command.StudentId;
                    studentInSubject.Grades = command.Grades;
                    studentInSubject.CreatedAt = DateTime.Now;
                    studentInSubject.UpdatedAt = DateTime.Now;

                    await _studentInSubjectService.CreateStudentInSubject(studentInSubject);
                }
                //Update the existing grades
                else
                {
                    existingGrade.Grades = command.Grades;
                    existingGrade.UpdatedAt = DateTime.Now;

                    await _studentInSubjectService.UpdateStudentInSubject(existingGrade);
                }
                //Update AngGrades as well

                var getAllGrades = await _studentInSubjectService.GetAllByStudentId(command.StudentId);

                if (getAllGrades != null && getAllGrades.Count > 0)
                {
                    var existingAvgGrade = await _assignedStudentService.GetByStudentId(command.StudentId);
                    if (existingAvgGrade != null)
                    {
                        existingAvgGrade.AvgGrade = (getAllGrades.Sum(a => a.Grades)) / getAllGrades.Count;
                        existingAvgGrade.UpdatedAt = DateTime.Now;

                        await _assignedStudentService.UpdateAssignedStudent(existingAvgGrade);
                    }
                }
                if (existingGrade != null)
                    return _mapper.Map<DTO_StudentInSubject>(existingGrade);
                else
                    return _mapper.Map<DTO_StudentInSubject>(studentInSubject);
            }
        }
    }
}
