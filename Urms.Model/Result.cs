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

        [Display(Name ="Vize")]
        [Required(ErrorMessage ="Lütfen vize notunu giriniz")]
        public double Visa { get; set; }

        [Display(Name = "Final")]
        [Required(ErrorMessage = "Lütfen final notunu giriniz")]
        public double Final { get; set; }

        [Display(Name ="Sonuc")]
        public double Res { get { return (Visa * (0.4)) + (Final * (0.6)); } }

        [Display(Name = "Bütünleme")]
        [Required(ErrorMessage = "Lütfen bütünleme notunu giriniz")]
        public string ResitExam { get; set; }


        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }

        public Graduate graduate { get; set; }
    }
    public enum Graduate
        {
            AA = 1,
            BA = 2,
            BB = 3,
            CB = 4,
            CC = 5,
            DC = 6,
            DD = 7,
            FF = 8
        }
    
}
