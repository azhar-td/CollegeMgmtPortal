using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMP.Data.Models
{
    public class AssignedStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [Required]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public int? AvgGrade { get; set; }
        //Foreign key references
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
