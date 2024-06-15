namespace EmployeeManagement.API.DataAccess.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ReadAll();
        Task<T> ReadSingle(Guid T);
        Task<string> Create(T entity);
        Task Update(Guid id, T entity);
        Task Delete(Guid id);
    }
}
