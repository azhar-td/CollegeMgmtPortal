using AutoMapper;
using CMP.Data.Models;
using CMP.Services.Interfaces;
using CollegeManagementPortal.DTO;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagementPortal.CQRS.Courses.Commands
{
    public class CreateCourseCommand : IRequest<DTO_Course>
    {
        [Required]
        public string Name { get; set; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, DTO_Course>
        {
            private IMapper _mapper;
            private ICourseService _courseService;
            public CreateCourseCommandHandler(IMapper mapper, ICourseService courseService)
            {
                _mapper = mapper;
                _courseService = courseService;
            }

            public async Task<DTO_Course> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
            {
                var course = new Course();
                course.Name = command.Name;
                course.CreatedAt = DateTime.Now;
                course.UpdatedAt = DateTime.Now;

                await _courseService.CreateCourse(course);

                return _mapper.Map<DTO_Course>(course);
            }
        }
    }
}
