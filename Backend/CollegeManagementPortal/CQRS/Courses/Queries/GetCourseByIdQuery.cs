using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Courses.Queries
{
    public class GetCourseByIdQuery : IRequest<DTO_Course>
    {
        public int Id { get; set; }

        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, DTO_Course>
        {
            private readonly ICourseService _courseService;
            private IMapper _mapper;

            public GetCourseByIdQueryHandler(ICourseService courseService, IMapper mapper)
            {
                _courseService = courseService;
                _mapper = mapper;
            }

            public async Task<DTO_Course> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
            {
                var course = await _courseService.GetCourseById(query.Id);
                var courseDTO = _mapper.Map<DTO_Course>(course);
                return courseDTO;
            }
        }
    }
}
