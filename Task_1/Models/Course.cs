using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_1.Models
{
    public class Course
    {
        // Change property for DB. In this case we can enter primary key(ID).
        // DB don't increment it automatically.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // Courses ID.
        public int CourseID { get; set; }
        // Title of course.
        public string Title { get; set; }
        // Courses cost.
        public int Credits { get; set; }

        // Uses in multiple entities(in our case it's Enrollments).
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}