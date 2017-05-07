using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;
using System.Data.Entity.ModelConfiguration;

namespace TestMigration.Repository.Mapping
{
   public class EmployeeMap:EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            this.HasKey(t => t.Id);
            this.HasMany(t => t.Order).WithMany(t => t.Employee).
                Map(act => act.ToTable("EmployeeOrder").
                MapLeftKey("EmployeeId").
                MapRightKey("OrderId"));
        }
    }
}
