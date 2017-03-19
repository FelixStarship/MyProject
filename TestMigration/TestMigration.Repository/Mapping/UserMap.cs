using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TestMigration.Domain.core;

namespace TestMigration.Repository.Mapping
{
   public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User", "dbo");
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id").IsRequired();
        }
    }
}
