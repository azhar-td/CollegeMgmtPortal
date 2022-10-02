using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace CollegeManagementPortal.CQRS.Students.Queries
{
    public class GetNewRegNumQuery : IRequest<string>
    {
        public class GetNewRegNumQueryHandler : IRequestHandler<GetNewRegNumQuery, string>
        {
            private readonly IStudentService _studentService;
            private IMapper _mapper;

            public GetNewRegNumQueryHandler(IStudentService stutentService, IMapper mapper)
            {
                _studentService = stutentService;
                _mapper = mapper;
            }

            public async Task<string> Handle(GetNewRegNumQuery query, CancellationToken cancellationToken)
            {
                return await _studentService.GetNewRegistrationNum();
            }
        }
    }
}
