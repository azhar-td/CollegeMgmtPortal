using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMP.Data.Models
{
    public class StudentInSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        [Required]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [Required]
        [RegularExpression(@"^[1-9][0-9]?$|^100$",
         ErrorMessage = "1 to 100 values allowed")]
        public int Grades { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        //Foreign key references
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
