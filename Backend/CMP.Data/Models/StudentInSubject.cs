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
        public int Grades { get; set; }
        //Foreign key references
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
