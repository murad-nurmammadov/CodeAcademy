using ProniaTemplate.Models;

namespace ProniaTemplate.Repositories.Interfaces;

public interface IRepository<T>
{
    Task<int> AddAsync(T entity);
    Task<int> DeleteAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
}
