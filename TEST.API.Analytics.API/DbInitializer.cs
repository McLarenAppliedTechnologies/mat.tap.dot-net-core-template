using System;
using System.Linq;
using TEST.API.Analytics.API.DO;

namespace TEST.API.Analytics.API
{
    public class DbInitializer
    {
        public static void Initialize(Model context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new StudentDO[]
            {
            new StudentDO{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new StudentDO{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentDO{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new StudentDO{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentDO{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new StudentDO{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new StudentDO{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new StudentDO{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (StudentDO s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var enrollments = new EnrollmentDO[]
            {
            new EnrollmentDO{StudentId=1,Grade=Grade.A},
            new EnrollmentDO{StudentId=1,Grade=Grade.C},
            new EnrollmentDO{StudentId=1,Grade=Grade.B},
            new EnrollmentDO{StudentId=2,Grade=Grade.B},
            new EnrollmentDO{StudentId=2,Grade=Grade.F},
            new EnrollmentDO{StudentId=2,Grade=Grade.F},
            new EnrollmentDO{StudentId=3},
            new EnrollmentDO{StudentId=4,},
            new EnrollmentDO{StudentId=4,Grade=Grade.F},
            new EnrollmentDO{StudentId=5,Grade=Grade.C},
            new EnrollmentDO{StudentId=6},
            new EnrollmentDO{StudentId=7,Grade=Grade.A},
            };
            foreach (EnrollmentDO e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
