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

            var courses = new CourseDO[]
            {
            new CourseDO{Id=1050,Title="Chemistry",Credits=3},
            new CourseDO{Id=4022,Title="Microeconomics",Credits=3},
            new CourseDO{Id=4041,Title="Macroeconomics",Credits=3},
            new CourseDO{Id=1045,Title="Calculus",Credits=4},
            new CourseDO{Id=3141,Title="Trigonometry",Credits=4},
            new CourseDO{Id=2021,Title="Composition",Credits=3},
            new CourseDO{Id=2042,Title="Literature",Credits=4}
            };
            foreach (CourseDO c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new EnrollmentDO[]
            {
            new EnrollmentDO{StudentId=1,CourseId=1050,Grade=Grade.A},
            new EnrollmentDO{StudentId=1,CourseId=4022,Grade=Grade.C},
            new EnrollmentDO{StudentId=1,CourseId=4041,Grade=Grade.B},
            new EnrollmentDO{StudentId=2,CourseId=1045,Grade=Grade.B},
            new EnrollmentDO{StudentId=2,CourseId=3141,Grade=Grade.F},
            new EnrollmentDO{StudentId=2,CourseId=2021,Grade=Grade.F},
            new EnrollmentDO{StudentId=3,CourseId=1050},
            new EnrollmentDO{StudentId=4,CourseId=1050},
            new EnrollmentDO{StudentId=4,CourseId=4022,Grade=Grade.F},
            new EnrollmentDO{StudentId=5,CourseId=4041,Grade=Grade.C},
            new EnrollmentDO{StudentId=6,CourseId=1045},
            new EnrollmentDO{StudentId=7,CourseId=3141,Grade=Grade.A},
            };
            foreach (EnrollmentDO e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
