namespace MVC_Practice.Repositories.Interfaces;

public interface IRepository<T>
{
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
}
