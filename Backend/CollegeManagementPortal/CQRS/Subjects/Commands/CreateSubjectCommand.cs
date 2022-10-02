using AutoMapper;
using CMP.Data.Models;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Subjects.Commands
{
    public class CreateSubjectCommand : IRequest<DTO_Subject>
    {
        [Required]
        public string Name { get; set; }

        public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, DTO_Subject>
        {
            private IMapper _mapper;
            private ISubjectService _subjectService;
            public CreateSubjectCommandHandler(IMapper mapper, ISubjectService subjectService)
            {
                _mapper = mapper;
                _subjectService = subjectService;
            }

            public async Task<DTO_Subject> Handle(CreateSubjectCommand command, CancellationToken cancellationToken)
            {
                var subject = new Subject();
                subject.Name = command.Name;
                subject.CreatedAt = DateTime.Now;
                subject.UpdatedAt = DateTime.Now;

                await _subjectService.CreateSubject(subject);

                return _mapper.Map<DTO_Subject>(subject);
            }
        }
    }
}
