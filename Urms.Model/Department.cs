using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urms.Model
{
   public  class Department:BaseEntity
    {




        [Display(Name = "Departman Kodu")]
        public string DeptCode { get; set; }
        [Display(Name = "Departman Kodu")]
        public string DeptName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
