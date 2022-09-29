using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data.Models
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}
