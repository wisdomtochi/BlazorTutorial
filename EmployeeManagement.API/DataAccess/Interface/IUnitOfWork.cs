namespace EmployeeManagement.API.DataAccess.Interface
{
    public interface IUnitOfWork<T> where T : class
    {
        public IGenericRepository<T> Repository { get; }
        public Task<bool> SaveAsync();
    }
}
