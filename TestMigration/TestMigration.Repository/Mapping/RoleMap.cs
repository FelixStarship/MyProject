using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TestMigration.Domain.core;

namespace TestMigration.Repository.Mapping
{
  public  class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Role");
            HasKey(t => t.Id);
        }
    }
}
