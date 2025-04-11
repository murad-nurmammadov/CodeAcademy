using Newtonsoft.Json;
using ProductManagementApp.Exceptions;

namespace ProductManagementApp.Models
{
    internal class Manager<T>
        where T : BaseEntity
    {
        // Fields
        private List<T> _entities = [];
        private string _path = "";

        // Properties
        public List<T> Entities
        {
            get
            {
                StreamReader sw = new StreamReader(_path);
                string json = sw.ReadToEnd();
                sw.Close();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            private set
            {
                _entities = value;
                string json = JsonConvert.SerializeObject(value);
                StreamWriter sw = new StreamWriter(_path);
                sw.Write(json);
                sw.Close();
            }
        }

        // Constuctor
        public Manager()
        {
            string classname = typeof(T).Name;
            _path = Path.Combine("..", "..", "..", ".", classname + "s.json");

            File.Create(_path).Close();
        }

        // Methods
        public void Add(T entity)
        {
            if (_entities.Any(e => e.Id == entity.Id))
                throw new EntityAlreadyExistsException();

            _entities.Add(entity);
            Entities = _entities;
        }

        public void Remove(int id)
        {
            if (!_entities.Any(e => e.Id == id))
                throw new EntityNotFoundException();

            T? entity = _entities.Find(e => e.Id == id);
            _entities.Remove(entity);
            Entities = _entities;
        }

        public void Update(int id, T updatedEntity)
        {
            T entity = _entities.Find(e => e.Id == id);
            int index = _entities.IndexOf(entity);
            _entities[index] = updatedEntity;
            Entities = _entities;
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
