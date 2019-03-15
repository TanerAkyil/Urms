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
    public enum sms
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
        Sixth = 6,
        Seventh = 7,
        Eighth = 8,
        Ninth = 9,
        Tenth = 10,
        Eleventh = 11,
        Twelveth = 12
    }
}
