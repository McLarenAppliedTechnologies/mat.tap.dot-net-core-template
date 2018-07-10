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
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        public StudentDO Student { get; set; }
    }
}
