using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Students.Queries
{
    public class GetAllUnAssignedStudentsQuery : IRequest<IEnumerable<DTO_Student>>
    {
        public class GetAllUnAssignedStudentsQueryHandler : IRequestHandler<GetAllUnAssignedStudentsQuery, IEnumerable<DTO_Student>>
        {
            private readonly IStudentService _studentService;
            private IMapper _mapper;

            public GetAllUnAssignedStudentsQueryHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Student>> Handle(GetAllUnAssignedStudentsQuery query, CancellationToken cancellationToken)
            {
                var unAssignedStudentList = await _studentService.GetAllUnAssignedStudents();
                var unAssignedStudentListDTO = _mapper.Map<IEnumerable<DTO_Student>>(unAssignedStudentList);
                return unAssignedStudentListDTO;
            }
        }
    }
}
