using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Urms.Model
{
    public class Teacher:BaseEntity
    {
        
        

        [Display(Name = "Akademisyen Adı")]
        [Required(ErrorMessage = "Lütfen akademisyen adını giriniz")]
        public string TeacherName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Lütfen bir adres giriniz")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Eposta giriniz")]
        [EmailAddress(ErrorMessage = "Geçersiz Email girişi"), StringLength(50)]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Enter Contact Number of Teacher")]
        public string ContactNo { get; set; }

        [Display(Name = "Designation")]
        
        public Guid? DesignationId { get; set; }

        [Display(Name = "Department")]
        
        public Guid? DeptId { get; set; }

        [Range(0.5, double.MaxValue, ErrorMessage = "Creadit can not be less than 0.5")]
        [Display(Name = "Creadit To Be Taken")]
        [Required(ErrorMessage = "Creadit to be taken by teacher?")]
        public double CreaditToBeTaken { set; get; }

        [DefaultValue(0.0)]
        public double RemaingCreadit { get; set; }

        
        public virtual Designation Designation { get; set; }

        
        public virtual Department Department { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
