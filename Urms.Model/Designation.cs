using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urms.Model
{
  public  class Designation:BaseEntity
    {
       
        

        [Display(Name = "Unvan Adı")]
        public string DesignationName { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
