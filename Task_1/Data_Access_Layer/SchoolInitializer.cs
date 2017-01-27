using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Task_1.Models;

namespace Task_1.Data_Access_Layer
{
    // Check condition of models and use algorithm of re-initialization if this need.
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        // Rewrite initialization for db. If model of db changes, tables in db "changes", too.
        protected override void Seed(SchoolContext context)
        {
            // List of students.
            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            // Adding data into table Students.
            students.ForEach(s => context.Students.Add(s));
            // Save and update DB.
            context.SaveChanges();

            // List of courses.
            var courses = new List<Course>
            {
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3, },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3, },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3, },
                new Course { CourseID = 1045, Title = "Calculus", Credits = 4, },
                new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4, },
                new Course { CourseID = 2021, Title = "Composition", Credits = 3, },
                new Course { CourseID = 2042, Title = "Literature", Credits = 4, }
            };

            // Adding data into table Courses.
            courses.ForEach(c => context.Courses.Add(c));
            // Save and update DB.
            context.SaveChanges();

            // List of enrollments between students and courses.
            var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentID = 1, CourseID = 1050, Grade = Grade.A },
                new Enrollment { StudentID = 1, CourseID = 4022, Grade = Grade.C },
                new Enrollment { StudentID = 1, CourseID = 4041, Grade = Grade.B },
                new Enrollment { StudentID = 2, CourseID = 1045, Grade = Grade.B },
                new Enrollment { StudentID = 2, CourseID = 3141, Grade = Grade.F },
                new Enrollment { StudentID = 2, CourseID = 2021, Grade = Grade.F },
                new Enrollment { StudentID = 3, CourseID = 1050 },
                new Enrollment { StudentID = 4, CourseID = 1050 },
                new Enrollment { StudentID = 4, CourseID = 4022, Grade = Grade.F },
                new Enrollment { StudentID = 5, CourseID = 4041, Grade = Grade.C },
                new Enrollment { StudentID = 6, CourseID = 1045 },
                new Enrollment { StudentID = 7, CourseID = 3141, Grade = Grade.A },
            };

            // Adding data into table Enrollments.
            enrollments.ForEach(e => context.Enrollments.Add(e));
            // Save and update DB.
            context.SaveChanges();
        }
    }
}