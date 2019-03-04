using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urms.Model
{
   public class Result:BaseEntity
    {
        
        public int ResultId { get; set; }

        [Required(ErrorMessage = "Lütfen Öğrenci Seçiniz")]
        [Display(Name = "Ögrenci Seçimi")]
        public int StudentId { get; set; }

        [Display(Name = "Ders Seçimi")]
        [Required(ErrorMessage = "Lütfen Ders Seçiniz")]
        public int CourseId { get; set; }


        [Display(Name = "Not Seçimi")]
        [Required(ErrorMessage = " Lütfen Not Seçiniz")]
        public string Grade { get; set; }


        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
