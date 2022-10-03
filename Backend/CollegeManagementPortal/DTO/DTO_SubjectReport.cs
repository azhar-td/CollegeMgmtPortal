namespace CollegeManagementPortal.DTO
{
    public class DTO_SubjectReport
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public int TeacherSalary { get; set; }
        public string TeacherBirthday { get; set; }
        public int NumOfStudents { get; set; }
        public int AvgGrade { get; set; }
    }
}
