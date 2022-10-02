using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Students.Queries
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<DTO_Student>>
    {
        public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<DTO_Student>>
        {
            private readonly IStudentService _studentService;
            private IMapper _mapper;

            public GetAllStudentsQueryHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
            {
                var studentList = await _studentService.GetAllStudents();
                var studentDTO = _mapper.Map<IEnumerable<DTO_Student>>(studentList);
                return studentDTO;
            }
        }
    }
}
