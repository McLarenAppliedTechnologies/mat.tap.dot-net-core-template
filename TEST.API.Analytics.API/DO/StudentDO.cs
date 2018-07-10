using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEST.API.Core.DataManagers;

namespace TEST.API.Analytics.API.DO
{
    public class StudentDO : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<EnrollmentDO> Enrollments { get; set; }
    }
}
