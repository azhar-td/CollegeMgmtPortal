using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagementPortal.DTO
{
    public class DTO_Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        public int Salary { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public ICollection<DTO_CourseDetail> CourseDetails { get; set; }
    }
}
