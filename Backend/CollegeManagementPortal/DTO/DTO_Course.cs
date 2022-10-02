using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementPortal.DTO
{
    public class DTO_Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
    }
}
