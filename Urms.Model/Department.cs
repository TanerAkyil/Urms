using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urms.Model
{
   public  class Department:BaseEntity
    {





         public string DeptCode { get; set; }
         public string DeptName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
