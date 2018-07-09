using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEST.API.Core.DataManagers;

namespace TEST.API.Analytics.API.DO
{
    public class StudentDO : IEntity
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Column]
        public string FirstMidName { get; set; }

        [Column]
        public DateTime EnrollmentDate { get; set; }

        [ForeignKey(nameof(EnrollmentDO.Id))]
        public ICollection<EnrollmentDO> Enrollments { get; set; }
    }
}
