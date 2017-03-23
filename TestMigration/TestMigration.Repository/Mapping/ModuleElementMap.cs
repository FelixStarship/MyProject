using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TestMigration.Domain.core;

namespace TestMigration.Repository.Mapping
{
   public class ModuleElementMap:EntityTypeConfiguration<ModuleElement>
    {
        public ModuleElementMap()
        {
            //this.ToTable("ModuleElement");
            this.HasKey(t => t.Id);

            //this.HasRequired(t => t.Module).WithMany(t=>t.ModuleElement).HasForeignKey(t => t.ModuleId);  外键实体中配置导航属性
        }   
    }
}
