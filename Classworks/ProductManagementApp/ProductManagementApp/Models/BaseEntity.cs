namespace ProductManagementApp.Models
{
    internal class BaseEntity
    {

        public int Id { get; private init; }

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}
