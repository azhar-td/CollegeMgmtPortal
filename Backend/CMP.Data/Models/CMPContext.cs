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
    }
}
