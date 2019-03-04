using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Model;

namespace Urms.Data.Builders
{
    public class DesignationBuilder
    {
        public DesignationBuilder(EntityTypeConfiguration<Designation> entity)
        {
            entity.HasKey(e => e.DesignationId);
            entity.Property(e => e.DesignationName).IsRequired().HasMaxLength(200);

        }
    }
}
