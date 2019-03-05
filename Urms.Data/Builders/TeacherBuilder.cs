using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Model;

namespace Urms.Data.Builders
{
        public class TeacherBuilder
    {
        public TeacherBuilder(EntityTypeConfiguration<Teacher> entity)
        {
           
            entity.Property(e => e.TeacherName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Address).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ContactNo).IsRequired().HasMaxLength(200);
            entity.HasOptional(e => e.Designation).WithMany(c => c.Teachers).HasForeignKey(p => p.DesignationId);
            entity.HasOptional(e => e.Department).WithMany(c => c.Teachers).HasForeignKey(p => p.DeptId);

        }
    }
}
