using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMigration.Domain.core;
using TestMigration.Domain.Interface;

namespace TestMigration.Repository
{   
    
    public class TestRepository:ITestPageRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IRepository<TestPage> _testPageRepository;
        public TestRepository(IDbContext dbContext,IRepository<TestPage> testPageRepository)
        {
            this._dbContext = dbContext;
            this._testPageRepository = testPageRepository;
        }
        public IQueryable<TestPage> GetTestPageList()
        {
            var model = this._testPageRepository.Find(null);
            return model;
        }
    }
}
