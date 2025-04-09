namespace QuizApp.Models
{
    internal class Quiz
    {
        // Fields
        private static byte _id = 0;

        // Properties
        public byte Id
        {
            get => _id;
            set => _id = value;
        }
        public string Name { get; set; } = "New Quiz";
        public List<Question> Questions { get; set; }

        // Constructor
        public Quiz(string name, List<Question> questions)
        {
            Id = ++_id;
            Name = name;
            Questions = questions;
        }
    }
}
