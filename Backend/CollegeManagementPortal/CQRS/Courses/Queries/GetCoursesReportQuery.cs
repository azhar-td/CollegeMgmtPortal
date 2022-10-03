using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Courses.Queries
{
    public class GetCoursesReportQuery : IRequest<IEnumerable<DTO_CoursesReport>>
    {
        public class GetCoursesReportQueryHandler : IRequestHandler<GetCoursesReportQuery, IEnumerable<DTO_CoursesReport>>
        {
            private readonly ICourseService _courseService;
            private readonly ICourseDetailService _courseDetailService;
            private readonly IAssignedStudentService _assignedStudentService;
            private IMapper _mapper;

            public GetCoursesReportQueryHandler(ICourseService courseService, 
                ICourseDetailService courseDetailService,
                IAssignedStudentService assignedStudentService,
                IMapper mapper)
            {
                _courseService = courseService;
                _courseDetailService = courseDetailService;
                _assignedStudentService = assignedStudentService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_CoursesReport>> Handle(GetCoursesReportQuery query, CancellationToken cancellationToken)
            {
                var report = new List<DTO_CoursesReport>();
                var courseList = await _courseService.GetAllCourses();

                foreach(var c in courseList)
                {
                    var courseDetails = await _courseDetailService.GetAllByCourseId(c.Id);
                    var assignedStudents = await _assignedStudentService.GetAllByCourseId(c.Id);
                    var reportObj = new DTO_CoursesReport();
                    reportObj.CourseId = c.Id;
                    reportObj.CourseName = c.Name;
                    reportObj.NumOfTeachers = courseDetails != null && courseDetails.Count() > 0 ? courseDetails.Count() : 0;
                    reportObj.NumOfStudents = assignedStudents != null && assignedStudents.Count() > 0 ? assignedStudents.Count() : 0;
                    reportObj.AvgGrade = assignedStudents != null && assignedStudents.Count() > 0 ? (assignedStudents.Sum(a => a.AvgGrade).Value) / assignedStudents.Count() : 0;
                    report.Add(reportObj);
                }
                
                return report;
            }
        }
    }
}
