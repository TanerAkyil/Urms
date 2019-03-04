using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urms.Model
{
    public class CourseAssign:BaseEntity
    {
        [Required]
        public int CourseAssignId { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        [Required]
        [Display(Name = "Course Code")]
        public int CourseId { get; set; }
    }
}
