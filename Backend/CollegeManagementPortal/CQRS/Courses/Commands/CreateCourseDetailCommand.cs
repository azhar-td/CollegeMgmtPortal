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
    public class CreateCourseDetailCommand : IRequest<DTO_CourseDetail>
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int TeacherId { get; set; }

        public class CreateCourseDetailCommandHandler : IRequestHandler<CreateCourseDetailCommand, DTO_CourseDetail>
        {
            private IMapper _mapper;
            private ICourseDetailService _courseDetailService;
            public CreateCourseDetailCommandHandler(IMapper mapper, ICourseDetailService courseDetailService)
            {
                _mapper = mapper;
                _courseDetailService = courseDetailService;
            }

            public async Task<DTO_CourseDetail> Handle(CreateCourseDetailCommand command, CancellationToken cancellationToken)
            {
                var courseDetail = new CourseDetail();
                courseDetail.CourseId = command.CourseId;
                courseDetail.SubjectId = command.SubjectId;
                courseDetail.TeacherId = command.TeacherId;
                courseDetail.CreatedAt = DateTime.Now;
                courseDetail.UpdatedAt = DateTime.Now;

                await _courseDetailService.CreateCourseDetail(courseDetail);

                return _mapper.Map<DTO_CourseDetail>(courseDetail);
            }
        }
    }
}
