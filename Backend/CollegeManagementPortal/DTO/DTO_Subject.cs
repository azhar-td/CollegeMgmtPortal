using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementPortal.DTO
{
    public class DTO_Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }

        public ICollection<DTO_CourseDetail> CourseDetails { get; set; }

        public ICollection<DTO_StudentInSubject> StudentInSubjects { get; set; }
    }
}
