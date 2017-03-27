using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain;
using TestMigration.Domain.core;
using TestMigration.Domain.Interface;

namespace TestMigration.Repository
{
    public  class UserRepository:IUserRepository
    {

        private readonly IDbContext _dbContext;
        private readonly IRepository<User> _userRepository;
        public UserRepository(IDbContext dbContext,IRepository<User> userRepository)
        {
            this._dbContext = dbContext;
            this._userRepository = userRepository;
        }
        public IEnumerable<User> LoadUsers(int pageindex, int pagesize)
        {
           return _dbContext.Set<User>().OrderBy(u => u.Id).Skip((pageindex - 1) * pagesize).Take(pagesize);
        }

        public IEnumerable<User> LoadInOrgs(params Guid[] orgId)
        {
            return this._userRepository.Find(t => t.CrateId == orgId[0]);
        }

        public int GetUserCntInOrgs(params Guid[] orgId)
        {
            return this._userRepository.GetCount(t => t.CrateId == orgId[0]);
        }
    }
}
