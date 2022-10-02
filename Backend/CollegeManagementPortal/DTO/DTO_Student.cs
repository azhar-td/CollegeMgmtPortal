using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagementPortal.DTO
{
    public class DTO_Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"(^[R])-[0-9]{4,6}$",
         ErrorMessage = "Characters are not allowed.")]
        public string RegNum { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public string Birthday { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }

        public ICollection<DTO_StudentInSubject> StudentInSubjects { get; set; }

        public ICollection<DTO_AssignedStudent> AssignedStudents { get; set; }
    }
}
