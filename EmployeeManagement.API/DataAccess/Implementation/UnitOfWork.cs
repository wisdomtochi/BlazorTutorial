using EmployeeManagement.API.Data.Context;
using EmployeeManagement.API.DataAccess.Interface;

namespace EmployeeManagement.API.DataAccess.Implementation
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private IGenericRepository<T> repository;
        private readonly EmployeeDbContext dbContext;

        public UnitOfWork(EmployeeDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IGenericRepository<T> Repository => repository ??= new GenericRepository<T>(dbContext);

        public async Task<bool> SaveAsync()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }
    }
}
