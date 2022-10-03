namespace CollegeManagementPortal.DTO
{
    public class DTO_CoursesReport
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int NumOfTeachers { get; set; }
        public int NumOfStudents { get; set; }
        public int AvgGrade { get; set; }
    }
}
