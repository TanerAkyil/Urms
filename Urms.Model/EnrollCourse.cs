using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urms.Model
{
    public class EnrollCourse:BaseEntity
    {
       
        public int EnrollId { get; set; }

        [Display(Name = "ogrenci kayıt no")]
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Gecersiz tarih formatı")]
        public DateTime EnrollDate { get; set; }
    }
}
