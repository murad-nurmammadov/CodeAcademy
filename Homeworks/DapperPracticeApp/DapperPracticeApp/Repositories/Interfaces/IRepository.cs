namespace DapperPracticeApp.Repositories.Interfaces;

internal interface IRepository<T>
{
    public int Add(T item);
    public int Update(T item);
    public int Delete(T item);
    public T GetById(int id);
    public List<T> GetAll();
}
