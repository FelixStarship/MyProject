using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TestMigration.Domain.core;
namespace TestMigration.Repository.Mapping
{
   public class TestPageMap:EntityTypeConfiguration<TestPage>
    {
        public TestPageMap()
        {
            this.HasKey(t => t.ID);
        }
    }
}
