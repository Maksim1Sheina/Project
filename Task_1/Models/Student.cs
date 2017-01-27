using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_1.Models
{
    public class Student
    {
        // Students ID.
        public int ID { get; set; }
        // Students LastName.
        public string LastName { get; set; }
        // Students FirstMidName.
        public string FirstMidName { get; set; }
        // Date of students enrollment.
        public DateTime EnrollmentDate { get; set; }

        // Uses in multiple entities(in our case it's Enrollments).
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}