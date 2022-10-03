using AutoMapper;
using CMP.Data;
using CMP.Data.Models;
using CMP.Services.Implementations;
using CMP.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CollegeManagementPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //DI for data layer
            services.AddRepository();
            services.AddDbContext<CMPContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Auto Mapper
            services.AddAutoMapper(typeof(Startup));
            //Services DI for Courses
            services.AddScoped<ICourseService, CourseService>();
            //Services DI for CourseDetail
            services.AddScoped<ICourseDetailService, CourseDetailService>();
            //Services DI for Subjects
            services.AddScoped<ISubjectService, SubjectService>();
            //Services DI for Teachers
            services.AddScoped<ITeacherService, TeacherService>();
            //Services DI for Student
            services.AddScoped<IStudentService, StudentService>();
            //Services DI for AssignedStudents
            services.AddScoped<IAssignedStudentService, AssignedStudentService>();
            //Services DI for StudentInSubject
            services.AddScoped<IStudentInSubjectService, StudentInSubjectService>();
            //Add MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //Add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CMP API",
                    Version = "v1",
                    Description = "College management portal.",
                    Contact = new OpenApiContact
                    {
                        Name = "M Azhar Rafique",
                        Email = "azhar.teradata@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/muhammad-azhar-rafique-55949991/"),
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMP API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
