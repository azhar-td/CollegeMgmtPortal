using CMP.Data.Models;
using CMP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data.Repository.Implementation
{
    public class AssignedStudentRepo : GenericRepo<AssignedStudent>, IAssignedStudentRepo
    {
        public AssignedStudentRepo(CMPContext cmpContext) : base(cmpContext)
        {

        }
    }
}
