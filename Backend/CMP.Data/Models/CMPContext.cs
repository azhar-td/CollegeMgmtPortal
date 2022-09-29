using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data.Models
{
    public class CMPContext: DbContext
    {
        public CMPContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<AssignedStudent> AssignedStudent { get; set; }
        public DbSet<CourseDetail> CourseDetail { get; set; }
        public DbSet<StudentInSubject> StudentInSubject { get; set; }
    }
}
