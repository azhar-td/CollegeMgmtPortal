using CMP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Interfaces
{
    public interface ICourseDetailService
    {
        Task<CourseDetail> CreateCourseDetail(CourseDetail courseDetail);
        Task<CourseDetail> UpdateCourseDetail(CourseDetail courseDetail);
        Task<IEnumerable<CourseDetail>> GetAllByCourseId(int courseId);
        Task<int> DeleteCourseDetail(CourseDetail courseDetail);
    }
}
