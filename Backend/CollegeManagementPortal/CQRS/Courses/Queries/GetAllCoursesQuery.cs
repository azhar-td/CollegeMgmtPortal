using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Courses.Queries
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<DTO_Course>>
    {
        public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<DTO_Course>>
        {
            private readonly ICourseService _courseService;
            private IMapper _mapper;

            public GetAllCoursesQueryHandler(ICourseService courseService, IMapper mapper)
            {
                _courseService = courseService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Course>> Handle(GetAllCoursesQuery query, CancellationToken cancellationToken)
            {
                var courseList = await _courseService.GetAllCourses();
                var courseDTO = _mapper.Map<IEnumerable<DTO_Course>>(courseList);
                return courseDTO;
            }
        }
    }
}
