using AutoMapper;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Students.Queries
{
    public class GetAllUnAssignedStudentsByCourseIdQuery : IRequest<IEnumerable<DTO_Student>>
    {
        public int CourseId { get; set; }

        public class GetAllUnAssignedStudentsByCourseIdQueryHandler : IRequestHandler<GetAllUnAssignedStudentsByCourseIdQuery, IEnumerable<DTO_Student>>
        {
            private readonly IStudentService _studentService;
            private IMapper _mapper;

            public GetAllUnAssignedStudentsByCourseIdQueryHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DTO_Student>> Handle(GetAllUnAssignedStudentsByCourseIdQuery query, CancellationToken cancellationToken)
            {
                var unAssignedStudentList = await _studentService.GetAllUnAssignedStudentsByCourseId(query.CourseId);
                var unAssignedStudentListDTO = _mapper.Map<IEnumerable<DTO_Student>>(unAssignedStudentList);
                return unAssignedStudentListDTO;
            }
        }
    }
}
