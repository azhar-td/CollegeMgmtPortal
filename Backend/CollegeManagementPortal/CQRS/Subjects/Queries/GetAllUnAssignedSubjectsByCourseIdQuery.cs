using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Subjects.Queries
{
    public class GetAllUnAssignedSubjectsByCourseIdQuery : IRequest<IEnumerable<DTO_Subject>>
    {
        public int CourseId { get; set; }

        public class GetAllUnAssignedSubjectsByCourseIdQueryHandler : IRequestHandler<GetAllUnAssignedSubjectsByCourseIdQuery, IEnumerable<DTO_Subject>>
        {
            private readonly ISubjectService _subjectService;
            private IMapper _mapper;

            public GetAllUnAssignedSubjectsByCourseIdQueryHandler(ISubjectService subjectService, IMapper mapper)
            {
                _subjectService = subjectService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Subject>> Handle(GetAllUnAssignedSubjectsByCourseIdQuery query, CancellationToken cancellationToken)
            {
                var unAssignedSubjectList = await _subjectService.GetAllUnAssignedSubjectsByCourseId(query.CourseId);
                var unAssignedSubjectListDTO = _mapper.Map<IEnumerable<DTO_Subject>>(unAssignedSubjectList);
                return unAssignedSubjectListDTO;
            }
        }
    }
}
