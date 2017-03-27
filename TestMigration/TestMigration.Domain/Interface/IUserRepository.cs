using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;

namespace TestMigration.Domain.Interface
{
   public interface IUserRepository
    {
        IEnumerable<User> LoadUsers(int pageindex, int pagesize);

        IEnumerable<User> LoadInOrgs(params Guid [] orgId);

        int GetUserCntInOrgs(params Guid [] orgId);
    }
}
