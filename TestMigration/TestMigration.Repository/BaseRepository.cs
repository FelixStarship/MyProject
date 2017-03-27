using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;
using TestMigration.Domain.Interface;
using Infrastructure;
using EntityFramework;
using System.Data.Entity.Migrations;
using EntityFramework.Extensions;


namespace TestMigration.Repository
{
    public class BaseRepository<T>:IRepository<T> where T:Entity
    {
        // protected TestMigrationContext Context = new TestMigrationContext();
        private readonly IDbContext _context;    //暂时公开
        private IDbSet<T> _entities;
        public BaseRepository(IDbContext context)
        {
            this._context = context;
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        /// <param name="exp">The exp.</param>
        public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }

        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        public T FindSingle(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="pageindex">The pageindex.</param>
        /// <param name="pagesize">The pagesize.</param>
        /// <param name="orderby">排序，格式如："Id"/"Id descending"</param>
        public IQueryable<T> Find(int pageindex, int pagesize, string orderby = "", Expression<Func<T, bool>> exp = null)
        {
            if (pageindex < 1) pageindex = 1;
            if (string.IsNullOrEmpty(orderby))
                orderby = "Id descending";

            return Filter(exp).OrderBy(orderby).Skip(pagesize * (pageindex - 1)).Take(pagesize);
        }

        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }

        public void Add(T entity)
        {

            _context.Set<T>().Add(entity);
            Save();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void BatchAdd(T[] entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                foreach (var entity in entities)
                {
                    if (entity == null)
                        throw new ArgumentNullException("entity");
                    _context.Set<T>().Add(entity);
                    Save();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(T entity)
        {
            var entry = this._context.Entry(entity);
            //todo:如果状态没有任何更改，会报错
            entry.State = EntityState.Modified;

            Save();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            Save();
        }

        /// <summary>
        /// 按指定id更新实体,会更新整个实体
        /// </summary>
        /// <param name="identityExp">The identity exp.</param>
        /// <param name="entity">The entity.</param>
        public void Update(Expression<Func<T, object>> identityExp, T entity)
        {
            _context.Set<T>().AddOrUpdate(identityExp, entity);
            Save();
        }

        /// <summary>
        /// 实现按需要只更新部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="entity">The entity.</param>
        public void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            _context.Set<T>().Where(where).Update(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> exp)
        {
            _context.Set<T>().Where(exp).Delete();
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw new Exception(e.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
            }
        }

        private IQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = _context.Set<T>().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }
    }
}
