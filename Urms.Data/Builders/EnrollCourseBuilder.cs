using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Model;

namespace Urms.Data.Builders
{
   public class EnrollCourseBuilder
    {
        public EnrollCourseBuilder(EntityTypeConfiguration<EnrollCourse> entity)
        {
            entity.HasKey(e => e.EnrollId);
        }
    }
}
