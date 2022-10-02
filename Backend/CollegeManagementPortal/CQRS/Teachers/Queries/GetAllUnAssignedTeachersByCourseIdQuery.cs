using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Teachers.Queries
{
    public class GetAllUnAssignedTeachersByCourseIdQuery : IRequest<IEnumerable<DTO_Teacher>>
    {
        public int CourseId { get; set; }

        public class GetAllUnAssignedTeachersByCourseIdQueryHandler : IRequestHandler<GetAllUnAssignedTeachersByCourseIdQuery, IEnumerable<DTO_Teacher>>
        {
            private readonly ITeacherService _teacherService;
            private IMapper _mapper;

            public GetAllUnAssignedTeachersByCourseIdQueryHandler(ITeacherService teacherService, IMapper mapper)
            {
                _teacherService = teacherService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Teacher>> Handle(GetAllUnAssignedTeachersByCourseIdQuery query, CancellationToken cancellationToken)
            {
                var unAssignedTeacherList = await _teacherService.GetAllUnAssignedTeachersByCourseId(query.CourseId);
                var unAssignedTeacherListDTO = _mapper.Map<IEnumerable<DTO_Teacher>>(unAssignedTeacherList);
                return unAssignedTeacherListDTO;
            }
        }
    }
}
