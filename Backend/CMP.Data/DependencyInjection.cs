using CMP.Data.Repository.Implementation;
using CMP.Data.Repository.Interfaces;
using CMP.Data.UnitOfWork.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<ICourseRepo, CourseRepo>();
            services.AddTransient<ISubjectRepo, SubjectRepo>();
            services.AddTransient<ITeacherRepo, TeacherRepo>();
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient<ICourseDetailRepo, CourseDetailRepo>();
            services.AddTransient<IAssignedStudentRepo, AssignedStudentRepo>();
            services.AddTransient<IStudentInSubjectRepo, StudentInSubjectRepo>();
            services.AddTransient<IUnitOfWork, CMP.Data.UnitOfWork.Implementation.UnitOfWork>();
            return services;
        }
    }
}
