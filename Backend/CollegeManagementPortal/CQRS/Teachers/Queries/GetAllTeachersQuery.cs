using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Teachers.Queries
{
    public class GetAllTeachersQuery : IRequest<IEnumerable<DTO_Teacher>>
    {
        public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, IEnumerable<DTO_Teacher>>
        {
            private readonly ITeacherService _teacherService;
            private IMapper _mapper;

            public GetAllTeachersQueryHandler(ITeacherService teacherService, IMapper mapper)
            {
                _teacherService = teacherService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Teacher>> Handle(GetAllTeachersQuery query, CancellationToken cancellationToken)
            {
                var teacherList = await _teacherService.GetAllTeachers();
                var teacherDTO = _mapper.Map<IEnumerable<DTO_Teacher>>(teacherList);
                return teacherDTO;
            }
        }
    }
}
