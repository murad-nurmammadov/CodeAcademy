namespace PizzaMizzaApp.Repositories.Interfaces;

internal interface IRepository<T>
{
    public int Add(T product);
    public int Delete(int id);
    public int Update(T product);
    public T GetById(int id);
    public List<T> GetAll();
}
