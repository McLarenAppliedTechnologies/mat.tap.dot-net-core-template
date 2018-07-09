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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column]
        public int Id { get; set; }
        
        [Column]
        public string Title { get; set; }

        [Column]
        public int Credits { get; set; }

        [ForeignKey(nameof(EnrollmentDO.Id))]
        public ICollection<EnrollmentDO> Enrollments { get; set; }
    }
}
