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
        
        
        [Display(Name = "Department")]
        public Guid? DepartmentId { get; set; }
        
        [Display(Name = "Teacher")]
        public Guid? TeacherId { get; set; }
        
        [Display(Name = "Course Code")]
        public Guid? CourseId { get; set; }
    }
}
