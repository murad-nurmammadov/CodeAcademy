namespace Models
{
    public class Book
    {
        private int _id;
        public string Title { get; set; }
        public string Author { get; set; }
        public ushort PublishedYear { get; set; }

        public Book(int id, string title, string author, ushort publishedYear)
        {
            if (id >= 0)
            {
                Id = id;
            }
            Title = title;
            Author = author;
            PublishedYear = publishedYear;
        }

        public int Id
        {
            get { return _id; }
            internal set
            {
                if (value >= -1)
                {
                    _id = value;
                }
            }
        }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Author: {Author}, Year: {PublishedYear}";
        }
    }
}
