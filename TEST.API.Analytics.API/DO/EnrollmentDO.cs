using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEST.API.Core.DataManagers;

namespace TEST.API.Analytics.API.DO
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class EnrollmentDO : IEntity
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        public int CourseID { get; set; }

        [Column]
        public int StudentID { get; set; }

        [Column]
        public Grade? Grade { get; set; }

        [ForeignKey(nameof(CourseDO.Id))]
        public CourseDO Course { get; set; }

        [ForeignKey(nameof(StudentDO.Id))]
        public StudentDO Student { get; set; }
    }
}
