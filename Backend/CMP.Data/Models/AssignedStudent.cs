using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data.Models
{
    public class AssignedStudent
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int AvgGrade { get; set; }
    }
}
