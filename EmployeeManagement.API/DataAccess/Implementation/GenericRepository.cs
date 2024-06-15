using EmployeeManagement.API.DataAccess.Interface;

namespace EmployeeManagement.API.DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<string> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> ReadSingle(Guid T)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
