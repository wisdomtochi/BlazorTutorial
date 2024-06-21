namespace EmployeeManagement.API.DataAccess.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ReadAll();
        Task<T> ReadSingle(Guid id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
