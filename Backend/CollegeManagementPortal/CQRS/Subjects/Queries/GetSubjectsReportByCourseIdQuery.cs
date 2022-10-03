using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Subjects.Queries
{
    public class GetSubjectsReportByCourseIdQuery : IRequest<IEnumerable<DTO_SubjectReport>>
    {
        public int CourseId { get; set; }

        public class GetSubjectsReportByCourseIdQueryHandler : IRequestHandler<GetSubjectsReportByCourseIdQuery, IEnumerable<DTO_SubjectReport>>
        {
            private readonly ICourseDetailService _courseDetailService;
            private readonly IStudentInSubjectService _studentInSubjectService;
            private IMapper _mapper;

            public GetSubjectsReportByCourseIdQueryHandler(ICourseDetailService courseDetailService,
                IStudentInSubjectService studentInSubjectService,
                IMapper mapper)
            {
                _courseDetailService = courseDetailService;
                _studentInSubjectService = studentInSubjectService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_SubjectReport>> Handle(GetSubjectsReportByCourseIdQuery query, CancellationToken cancellationToken)
            {
                var report = new List<DTO_SubjectReport>();

                var courseDetailList = await _courseDetailService.GetAllByCourseId(query.CourseId);

                foreach (var c in courseDetailList)
                {
                    var studentToSubject = await _studentInSubjectService.GetAllBySubjectId(c.SubjectId);
                    var teacherDto = _mapper.Map<DTO_Teacher>(c.Teacher);
                    var reportObj = new DTO_SubjectReport();
                    reportObj.SubjectId = c.Subject.Id;
                    reportObj.SubjectName = c.Subject.Name;
                    reportObj.TeacherName = teacherDto.Name;
                    reportObj.TeacherBirthday = teacherDto.Birthday;
                    reportObj.TeacherSalary = teacherDto.Salary;
                    reportObj.NumOfStudents = studentToSubject != null && studentToSubject.Count() > 0 ? studentToSubject.Count() : 0;
                    reportObj.AvgGrade = studentToSubject != null && studentToSubject.Count() > 0 ? (studentToSubject.Sum(a=>a.Grades)) / studentToSubject.Count() : 0;
                    report.Add(reportObj);
                }

                return report;
            }
        }
    }
}
