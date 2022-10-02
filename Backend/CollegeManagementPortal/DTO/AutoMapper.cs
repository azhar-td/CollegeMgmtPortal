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
            // map from Course to DTO_Course
            CreateMap<Course, DTO_Course>()
                .ForMember(x => x.CreatedAt,
                    opt => opt.MapFrom(src => (src.CreatedAt).ToString("dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(x => x.UpdatedAt,
                    opt => opt.MapFrom(src => (src.UpdatedAt).ToString("dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture)));

            CreateMap<DTO_Teacher, Teacher>(); // map from DTO_Teacher to Teacher
            // map from Teacher to DTO_Teacher
            CreateMap<Teacher, DTO_Teacher>()
                 .ForMember(x => x.Birthday,
                    opt => opt.MapFrom(src => (src.Birthday).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)));

            CreateMap<DTO_CourseDetail, CourseDetail>(); // map from DTO_CourseDetail to CourseDetail
            CreateMap<CourseDetail, DTO_CourseDetail>(); // map from CourseDetail to DTO_CourseDetail

            CreateMap<DTO_Subject, Subject>(); // map from DTO_Subject to Subject
            // map from Subject to DTO_Subject
            CreateMap<Subject, DTO_Subject>()
                .ForMember(x => x.CreatedAt,
                    opt => opt.MapFrom(src => (src.CreatedAt).ToString("dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(x => x.UpdatedAt,
                    opt => opt.MapFrom(src => (src.UpdatedAt).ToString("dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture)));


            CreateMap<DTO_Subject, Subject>(); // map from DTO_Student to Student
            // map from Student to DTO_Student
            CreateMap<Student, DTO_Student>()
                .ForMember(x => x.CreatedAt,
                    opt => opt.MapFrom(src => (src.CreatedAt).ToString("dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(x => x.UpdatedAt,
                    opt => opt.MapFrom(src => (src.UpdatedAt).ToString("dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(x => x.Birthday,
                    opt => opt.MapFrom(src => (src.Birthday).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
