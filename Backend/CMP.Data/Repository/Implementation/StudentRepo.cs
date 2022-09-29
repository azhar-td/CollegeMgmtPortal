using CMP.Data.Models;
using CMP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data.Repository.Implementation
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(CMPContext cmpContext) : base(cmpContext)
        {

        }
    }
}
