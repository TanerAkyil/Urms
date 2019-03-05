using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Model;

namespace Urms.Data.Builders
{
   public class SemesterBuilder
    {
        public SemesterBuilder(EntityTypeConfiguration<Semester> entity)
        {
            
            entity.Property(e => e.SemesterName).IsRequired().HasMaxLength(100);
        }
    }
}
