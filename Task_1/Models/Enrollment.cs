using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Task_1.Models
{
    // Enum(list) of marks for graduation.
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        // Enrollments ID.
        public int ID { get; set; }

        // Courses ID(foreign key).
        public int CourseID { get; set; }

        // Students ID(foreign key).
        public int StudentID { get; set; }

        // Mark of graduation.
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }


        // Uses in multiple entities(keep entities between Courses and Students into Enrollments).
        public virtual Course Course { get; set; }
        // Uses in multiple entities(keep entities between Courses and Students into Enrollments).
        public virtual Student Student { get; set; }
    }
}