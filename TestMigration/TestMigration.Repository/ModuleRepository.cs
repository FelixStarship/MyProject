using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;
using TestMigration.Domain.Interface;
using System.Linq.Expressions;
using System.Data.Entity;


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

        public Task<List<T>> GetEntityListAsync<T>(Expression<Func<T, bool>> whereLambda, List<Expression<Func<T, object>>> propSelect = null, bool asNoTracking = true) where T : class
        {
            var result = whereLambda == null ? this._dbContext.Set<T>() : this._dbContext.Set<T>().Where(whereLambda);
            if (asNoTracking)
                result = result.AsNoTracking();
            if(propSelect!=null&&propSelect.Count()>0)
            {  foreach (var prop in propSelect)
                {
                    var fun = prop;
                    result = result.Include(fun);
                }
            }
            return result.ToListAsync();
        }
    }
}
