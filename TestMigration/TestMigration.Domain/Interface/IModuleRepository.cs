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

        Task<List<T>> GetEntityListAsync<T>(Expression<Func<T, bool>> whereLambda, List<Expression<Func<T, object>>> propSelect = null, bool asNoTracking = true) where T : class;
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        Task<ResultJson> InsertModule(ModuleElement module);
    }
}
