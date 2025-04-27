namespace DapperPracticeApp.Repositories.Interfaces;

internal interface IRepository<T>
{
    public Task<int> AddAsync(T item);
    public Task<int> UpdateAsync(T item);
    public Task<int> DeleteAsync(T item);
    public Task<T> GetByIdAsync(int id);
    public Task<List<T>> GetAllAsync();
}
