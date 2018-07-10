using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TEST.API.Core.DataManagers;

namespace TEST.API.Analytics.API.DO
{
    public class CourseDO : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<EnrollmentDO> Enrollments { get; set; }
    }
}
