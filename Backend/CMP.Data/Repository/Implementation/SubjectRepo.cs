using CMP.Data.Models;
using CMP.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data.Repository.Implementation
{
    public class SubjectRepo : GenericRepo<Subject>, ISubjectRepo
    {
        public SubjectRepo(CMPContext cmpContext) : base(cmpContext)
        {

        }
    }
}
