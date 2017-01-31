using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Task_1.Data_Access_Layer
{
    // Our class inherit all from Dbcontext for interaction with DataBase.
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssigments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor"));

            modelBuilder.Entity<Instructor>()
               .HasOptional(p => p.OfficeAssignment)
               .WithRequired(p => p.Instructor);

            modelBuilder.Entity<Department>()
               .HasOptional(x => x.Administrator);
        }



        /*
        // Default constructor for db context. 
        // It used through description in Web.config.
        public SchoolContext() : base("SchoolContext")
        {
        }

        // Context for table of Students.
        public DbSet<Student> Students { get; set; }
        // Context for table of Enrollments.
        public DbSet<Enrollment> Enrollments { get; set; }
        // Context for table of Courses.
        public DbSet<Course> Courses { get; set; }

        // Description of action on model creating.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // It's usign for truncate table names. 
            // With this action we have table Student, table Enrollment and table Course 
            // instead Students, Enrollments and Courses.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        */
    }
}