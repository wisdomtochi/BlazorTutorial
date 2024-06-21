using EmployeeManagement.API.Data.Context;
using EmployeeManagement.API.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EmployeeDbContext dbContext;
        private readonly DbSet<T> table;

        public GenericRepository(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.table = dbContext.Set<T>();
        }

        public async Task<T> ReadSingle(Guid id)
        {
            var entity = await table.FindAsync(id);
            return entity;
        }
        public async Task<IEnumerable<T>> ReadAll()
        {
            return await table.ToListAsync();
        }

        public async Task Create(T entity)
        {
            await table.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await table.FindAsync(id);
            table.Remove(entity);
        }

        public async Task Update(T entity)
        {
            var updateEntity = table.Attach(entity);
            updateEntity.State = EntityState.Modified;
        }
    }
}
