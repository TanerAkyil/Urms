using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Model;

namespace Urms.Data.Builders
{
    public class StudentBuilder
    {
        public StudentBuilder(EntityTypeConfiguration<Student> entity)
        {
            
            entity.Property(e => e.StudentName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ContactNo).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Address).IsRequired().HasMaxLength(200);
            entity.Property(e => e.RegNo).IsRequired().HasMaxLength(200);
            entity.HasOptional(e => e.Department).WithMany(c => c.Students).HasForeignKey(p => p.DeptId);

        }
    }
}
