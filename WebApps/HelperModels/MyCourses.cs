using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.HelperModels
{
    public class MyCourses
    {
        [Key]
        public string emailID { get; set; }
        public string CourseId { get; set; }
        public string enrollmentDate { get; set; }
    }
}
