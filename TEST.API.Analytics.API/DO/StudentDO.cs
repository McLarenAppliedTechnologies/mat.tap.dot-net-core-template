using System;
using System.Collections.Generic;

namespace TEST.API.Analytics.API.DO
{
    public class StudentDO
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<EnrollmentDO> Enrollments { get; set; }
    }
}
