using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;
using System.Linq.Expressions;


namespace TestMigration.Domain.Interface
{
  public interface  IModuleRepository
    {
        bool AddUser(Module module);
    }
}
