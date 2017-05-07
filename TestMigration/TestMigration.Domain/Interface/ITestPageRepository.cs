using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;

namespace TestMigration.Domain.Interface
{  

    public interface ITestPageRepository
    {
        IQueryable<TestPage> GetTestPageList();
    }
}
