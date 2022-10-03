using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Students.Queries
{
    public class GetStudentsReportBySubjectIdQuery : IRequest<IEnumerable<DTO_StudentReport>>
    {
        public int SubjectId { get; set; }

        public class GetStudentsReportBySubjectIdQueryHandler : IRequestHandler<GetStudentsReportBySubjectIdQuery, IEnumerable<DTO_StudentReport>>
        {
            private readonly IStudentInSubjectService _studentInSubjectService;
            private IMapper _mapper;

            public GetStudentsReportBySubjectIdQueryHandler(IStudentInSubjectService studentInSubjectService,
                IMapper mapper)
            {
                _studentInSubjectService = studentInSubjectService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_StudentReport>> Handle(GetStudentsReportBySubjectIdQuery query, CancellationToken cancellationToken)
            {
                var report = new List<DTO_StudentReport>();

                var studentInSubjects = await _studentInSubjectService.GetAllBySubjectId(query.SubjectId);

                foreach (var s in studentInSubjects)
                {
                    var studentDto = _mapper.Map<DTO_Student>(s.Student);
                    var reportObj = new DTO_StudentReport();

                    reportObj.StudentId = studentDto.Id;
                    reportObj.StudentName = studentDto.Name;
                    reportObj.Birthday = studentDto.Birthday;
                    reportObj.RegNum = studentDto.RegNum;
                    reportObj.Grades = s.Grades;
                    
                    report.Add(reportObj);
                }

                return report;
            }
        }
    }
}
