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
        
        

        
        [Display(Name = "Ögrenci Seçimi")]
        public Guid? StudentId { get; set; }

        [Display(Name = "Ders Seçimi")]
        
        public Guid? CourseId { get; set; }


        [Display(Name = "Not Seçimi")]
        [Required(ErrorMessage = " Lütfen Not Seçiniz")]
        public string Grade { get; set; }


        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
