namespace TEST.API.Analytics.API.DO
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class EnrollmentDO
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public CourseDO Course { get; set; }
        public StudentDO Student { get; set; }
    }
}
