using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_1.Models
{
    public class Student
    {
        // Students ID.
        public int ID { get; set; }

        // Students LastName.
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "String length cannot be longer than 50 characters.", MinimumLength = 1)]
        [Display(Name = "Last Name", Description = "Enter last name")]
        // Regular expression, that return all alphabetic and numeric symbols and symbols . and _, too.
        [RegularExpression(@"^[\w\._]")]
        public string LastName { get; set; }

        // Students FirstMidName.
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "String length cannot be longer than 50 characters.", MinimumLength = 1)]
        [Column("FirstName")]
        [Display(Name = "First Name", Description = "Enter first name")]
        public string FirstMidName { get; set; }

        // Date of students enrollment.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date", Description = "Enter enrollment date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        // Uses in multiple entities(in our case it's Enrollments).
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}