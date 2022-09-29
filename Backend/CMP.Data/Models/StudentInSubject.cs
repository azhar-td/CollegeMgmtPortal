using System;
using System.Collections.Generic;
using System.Text;

namespace CMP.Data.Models
{
    public class StudentInSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public int Grades { get; set; }
    }
}
