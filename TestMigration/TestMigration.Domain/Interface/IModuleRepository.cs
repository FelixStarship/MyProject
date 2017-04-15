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
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="propSelect"></param>
        /// <returns></returns>
        Task<TResult> GetSinglePropertyAsync<T, TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> propSelect) where T : class;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="propSelect"></param>
        /// <param name="asNoTracking"></param>
        /// <returns></returns>
        Task<TResult> FindEntityAsync<TResult>(Expression<Func<TResult, bool>> whereLambda, List<Expression<Func<TResult, object>>> propSelect = null, bool asNoTracking = true) where TResult : class;
    }
}
