using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Students.Queries
{
    public class GetAllAssignedStudentsByCourseIdQuery : IRequest<IEnumerable<DTO_Student>>
    {
        public int CourseId { get; set; }

        public class GetAllAssignedStudentsByCourseIdQueryHandler : IRequestHandler<GetAllAssignedStudentsByCourseIdQuery, IEnumerable<DTO_Student>>
        {
            private readonly IStudentService _studentService;
            private IMapper _mapper;

            public GetAllAssignedStudentsByCourseIdQueryHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Student>> Handle(GetAllAssignedStudentsByCourseIdQuery query, CancellationToken cancellationToken)
            {
                var assignedStudentList = await _studentService.GetAllAssignedStudentsByCourseId(query.CourseId);
                var assignedStudentListDTO = _mapper.Map<IEnumerable<DTO_Student>>(assignedStudentList);
                return assignedStudentListDTO;
            }
        }
    }
}
