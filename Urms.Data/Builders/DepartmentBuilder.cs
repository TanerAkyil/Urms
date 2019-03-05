using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Model;

namespace Urms.Data.Builders
{
   public class DepartmentBuilder
    {
        public DepartmentBuilder(EntityTypeConfiguration<Department> entity)
        {
           
            entity.Property(d => d.DeptCode).IsRequired().HasMaxLength(100);
            entity.Property(d => d.DeptName).IsRequired().HasMaxLength(100);
        }
    }
}
