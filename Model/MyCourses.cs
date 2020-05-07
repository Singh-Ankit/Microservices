using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class MyCourses
    {
        [Key]
        public int itemID { get; set; }
        [Column("Email ID")]
        public string emailID { get; set; }
        [Column("Course ID")]
        public string CourseId { get; set; }
        [Column("Enrollment Date")]
        public string enrollmentDate { get; set; }
    }
}
