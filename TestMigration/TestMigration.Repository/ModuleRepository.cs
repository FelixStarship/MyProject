using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;
using TestMigration.Domain.Interface;
using System.Linq.Expressions;


namespace TestMigration.Repository
{
   public class ModuleRepository:IModuleRepository
    {

        private readonly IDbContext _dbContext;
        private readonly IRepository<Module> _moduleRepository;
        public ModuleRepository(IDbContext dbContext, IRepository<Module> moduleRepository)
        {
            this._dbContext = dbContext;
            this._moduleRepository = moduleRepository;
        }

        public bool AddUser(Module module)
        {
            return this._moduleRepository.Add(module);
        }
    }
}
