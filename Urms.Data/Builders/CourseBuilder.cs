using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Model;

namespace Urms.Data.Builders
{
   public class CourseBuilder
    {
        public CourseBuilder(EntityTypeConfiguration<Course> entity)
        {
           
            entity.Property(e => e.CourseName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CourseCode).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Credit).IsRequired();
            entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            entity.HasOptional(e => e.Teacher).WithMany(c => c.Courses).HasForeignKey(p => p.TeacherId);
            entity.HasOptional(e => e.Department).WithMany(c => c.Courses).HasForeignKey(p => p.DeptId);
            entity.HasOptional(e => e.Semester).WithMany(c => c.Courses).HasForeignKey(p => p.SemesterId);
        }
    }
}
