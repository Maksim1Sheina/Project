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
    }
}