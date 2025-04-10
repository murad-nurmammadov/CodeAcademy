using ProductManagementApp.Exceptions;

namespace ProductManagementApp.Models
{
    internal class Manager<T>
        where T : BaseEntity
    {
        // Fields
        private List<T> _entities = [];

        // Properties
        public List<T> Entities { get => _entities; }

        // Methods
        public void Add(T entity)
        {
            if (_entities.Any(e => e.Id == entity.Id))
                throw new EntityAlreadyExistsException();

            _entities.Add(entity);
        }

        public void Remove(int id)
        {
            if (!_entities.Any(e => e.Id == id))
                throw new EntityNotFoundException();

            T entity = _entities.Find(e => e.Id == id);
            _entities.Remove(entity);
        }

        public void Update(int id, T updatedEntity)
        {
            T entity = _entities.Find(e => e.Id == id);
            _entities.Remove(entity);
            _entities.Add(updatedEntity);
        }

        public T GetById(int id)
        {
            if (!_entities.Any(e => e.Id == id))
                throw new EntityNotFoundException();

            return _entities.Find(e => e.Id == id);
        }

        public void GetAll()
        {
            _entities.ForEach(Console.WriteLine);
        }
    }
}
