using AutoMapper;
using CMP.Data.Models;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Students.Commands
{
    public class CreateStudentCommand : IRequest<DTO_Student>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        [Required]
        [RegularExpression(@"(^[R])-[0-9]{4,6}$",
         ErrorMessage = "Characters are not allowed.")]
        public string RegNum { get; set; }

        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, DTO_Student>
        {
            private IMapper _mapper;
            private IStudentService _studentService;
            public CreateStudentCommandHandler(IMapper mapper, IStudentService studentService)
            {
                _mapper = mapper;
                _studentService = studentService;
            }

            public async Task<DTO_Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = new Student();
                student.Name = command.Name;
                student.Birthday = command.Birthday;
                student.RegNum = command.RegNum;
                student.CreatedAt = DateTime.Now;
                student.UpdatedAt = DateTime.Now;

                await _studentService.CreateStudent(student);

                return _mapper.Map<DTO_Student>(student);
            }
        }
    }
}
