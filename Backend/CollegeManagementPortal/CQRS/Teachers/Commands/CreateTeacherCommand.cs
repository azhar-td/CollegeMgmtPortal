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

namespace CollegeManagementPortal.CQRS.Teachers.Commands
{
    public class CreateTeacherCommand : IRequest<DTO_Teacher>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        [Required]
        public int Salary { get; set; }

        public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, DTO_Teacher>
        {
            private IMapper _mapper;
            private ITeacherService _teacherService;
            public CreateTeacherCommandHandler(IMapper mapper, ITeacherService teacherService)
            {
                _mapper = mapper;
                _teacherService = teacherService;
            }

            public async Task<DTO_Teacher> Handle(CreateTeacherCommand command, CancellationToken cancellationToken)
            {
                var teacher = new Teacher();
                teacher.Name = command.Name;
                teacher.Birthday = command.Birthday;
                teacher.Salary = command.Salary;
                teacher.CreatedAt = DateTime.Now;
                teacher.UpdatedAt = DateTime.Now;

                await _teacherService.CreateTeacher(teacher);

                return _mapper.Map<DTO_Teacher>(teacher);
            }
        }
    }
}
