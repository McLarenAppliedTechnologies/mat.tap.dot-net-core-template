using Microsoft.EntityFrameworkCore;
using TEST.API.Analytics.API.DO;

namespace TEST.API.Analytics.API
{
    public class Model : DbContext
    {
        public Model(DbContextOptions<Model> options) : base(options)
        {
        }

        public DbSet<CourseDO> Courses { get; set; }
        public DbSet<EnrollmentDO> Enrollments { get; set; }
        public DbSet<StudentDO> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDO>().ToTable("Course");
            modelBuilder.Entity<EnrollmentDO>().ToTable("Enrollment");
            modelBuilder.Entity<StudentDO>().ToTable("Student");
        }
    }
}
