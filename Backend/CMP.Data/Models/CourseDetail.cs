using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CMP.Data.Models
{
    public class CourseDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [Required]
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        [Required]
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        //Foreign key references
        public Course Course { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
