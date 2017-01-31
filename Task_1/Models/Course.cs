using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_1.Models
{
    public class Course
    {
        // Change property for DB. In this case we can enter primary key(ID).
        // DB don't increment it automatically.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // Courses ID.
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        // Title of course.
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        // Courses cost.
        [Range(0,5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        // Uses in multiple entities(in our case it's Enrollments).
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}