using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Model;

namespace Urms.Data.Builders
{
      public class ResultBuilder
    {
        public ResultBuilder(EntityTypeConfiguration<Result> entity)
        {
            
            entity.Property(e => e.Grade).IsRequired().HasMaxLength(200);
            entity.HasOptional(e => e.Student).WithMany(c => c.Results).HasForeignKey(p => p.StudentId);
            entity.HasOptional(e => e.Course).WithMany(c => c.Results).HasForeignKey(p => p.CourseId);
        }
    }
}
