using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TestMigration.Domain.core;

namespace TestMigration.Repository.Mapping
{
    public class ModuleMap:EntityTypeConfiguration<Module>
    {
        public ModuleMap()
        {
            //ToTable("Module");
            this.HasKey(t => t.Id);
            this.HasMany(t => t.ModuleElement).WithRequired().HasForeignKey(t =>t.ModuleId);   //主键表配置导航属性
        }
    }
}
