using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementPortal.DTO
{
    public class DTO_AssignedStudent
    {
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        public int? AvgGrade { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }

        public DTO_Course Course { get; set; }
        public DTO_Student Student { get; set; }
    }
}
