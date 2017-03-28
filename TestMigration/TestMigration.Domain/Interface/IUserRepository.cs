using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;
using System.Linq.Expressions;

namespace TestMigration.Domain.Interface
{
   public interface IUserRepository
    {
        IEnumerable<User> LoadUsers(int pageindex, int pagesize);

        IEnumerable<User> LoadInOrgs(params Guid [] orgId);

        int GetUserCntInOrgs(params Guid [] orgId);

        User FindUser(Expression<Func<User, bool>> exp);

        bool AddUser(User user);
    }
}
