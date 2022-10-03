using System.ComponentModel.DataAnnotations;

namespace CollegeManagementPortal.DTO
{
    public class DTO_StudentInSubject
    {
        public int Id { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [RegularExpression(@"^[1-9][0-9]?$|^100$",
         ErrorMessage = "1 to 100 values allowed")]
        public int Grades { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
        //Foreign key references
        public DTO_Subject Subject { get; set; }
        public DTO_Student Student { get; set; }
    }
}
