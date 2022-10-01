using AutoMapper;
using CMP.Data.Models;

namespace CollegeManagementPortal.DTO
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<DTO_Course, Course>(); // map from DTO_Course to Course
            CreateMap<Course, DTO_Course>(); // map from Course to DTO_Course
        }
    }
}
