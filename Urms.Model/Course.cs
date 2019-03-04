using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urms.Model
{
    public class Course:BaseEntity
    {
        [Display(Name = "Ders")]
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public double Credit { get; set; }
        public string Description { get; set; }
        public int DeptId { get; set; }
        public int SemesterId { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Department Department { get; set; }
        public virtual Semester Semester { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
