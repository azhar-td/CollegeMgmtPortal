using CMP.Data.Models;
using CMP.Data.UnitOfWork.Interfaces;
using CMP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Services.Implementations
{
    public class CourseDetailService : ICourseDetailService
    {
        IUnitOfWork _unitOfWork;

        public CourseDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseDetail> CreateCourseDetail(CourseDetail courseDetail)
        {
            _unitOfWork.CourseDetails.Create(courseDetail);
            await _unitOfWork.Complete();
            return courseDetail;
        }

        public async Task<int> DeleteCourseDetail(CourseDetail courseDetail)
        {
            _unitOfWork.CourseDetails.Delete(courseDetail);
            return await _unitOfWork.Complete();
        }

        public async Task<CourseDetail> UpdateCourseDetail(CourseDetail courseDetail)
        {
            _unitOfWork.CourseDetails
                .Update(courseDetail);
            await _unitOfWork.Complete();
            return courseDetail;
        }

        public async Task<IEnumerable<CourseDetail>> GetAllByCourseId(int courseId)
        {
            return await _unitOfWork.CourseDetails
                    .FindByCondition(a => a.CourseId == courseId)
                    .Include(a => a.Course)
                    .Include(a => a.Subject)
                    .Include(a => a.Teacher)
                    .ToListAsync();
        }
    }
}
