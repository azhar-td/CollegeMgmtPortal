using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Subjects.Queries
{
    public class GetAllSubjectsQuery : IRequest<IEnumerable<DTO_Subject>>
    {
        public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, IEnumerable<DTO_Subject>>
        {
            private readonly ISubjectService _subjectService;
            private IMapper _mapper;

            public GetAllSubjectsQueryHandler(ISubjectService subjectService, IMapper mapper)
            {
                _subjectService = subjectService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Subject>> Handle(GetAllSubjectsQuery query, CancellationToken cancellationToken)
            {
                var subjectList = await _subjectService.GetAllSubjects();
                var subjectDTO = _mapper.Map<IEnumerable<DTO_Subject>>(subjectList);
                return subjectDTO;
            }
        }
    }
}
