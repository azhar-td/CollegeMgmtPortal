using CMP.Data.Models;
using CMP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data.Repository.Implementation
{
    public class CourseDetailRepo : GenericRepo<CourseDetail>, ICourseDetailRepo
    {
        public CourseDetailRepo(CMPContext cmpContext) : base(cmpContext)
        {

        }
    }
}
