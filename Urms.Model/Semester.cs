using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urms.Model
{
    public class Semester:BaseEntity
    {
        
       

        [Display(Name = "Dönem Adı")]
        public string SemesterName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
