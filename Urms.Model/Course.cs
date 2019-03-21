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

        public Course()
        {
            Results = new HashSet<Result>();
        }
        [Display(Name = "Ders Kodu")]
        public string CourseCode { get; set; }
        [Display(Name = "Ders Adı  ")]
        public string CourseName { get; set; }
        [Display(Name = " Ders Kredisi")]
        public double Credit { get; set; }
        [Display(Name = "Ders Acıklaması")]
        public string Description { get; set; }
        [Display(Name = "Hangi Bölüm No")]
        public Guid? DeptId { get; set; }
        [Display(Name = "hangi  Dönem")]
        public Guid? SemesterId { get; set; }
        [Display(Name = "Ders Hocası")]
        public Guid? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Department Department { get; set; }
        public virtual Semester Semester { get; set; }
        public ICollection<Result> Results { get; set; }
        public SmsEnum smsEnum { get; set; }

    }
    public enum SmsEnum
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
