using AutoMapper;
using CMP.Data.Models;
using System.Globalization;

namespace CollegeManagementPortal.DTO
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<DTO_Course, Course>(); // map from DTO_Course to Course
            CreateMap<Course, DTO_Course>(); // map from Course to DTO_Course

            CreateMap<DTO_Teacher, Teacher>(); // map from DTO_Teacher to Teacher
            // map from Teacher to DTO_Teacher
            CreateMap<Teacher, DTO_Teacher>()
                 .ForMember(x => x.Birthday,
                    opt => opt.MapFrom(src => (src.Birthday).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)));

            CreateMap<DTO_CourseDetail, CourseDetail>(); // map from DTO_CourseDetail to CourseDetail
            CreateMap<CourseDetail, DTO_CourseDetail>(); // map from CourseDetail to DTO_CourseDetail
        }
    }
}
