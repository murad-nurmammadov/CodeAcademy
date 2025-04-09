namespace QuizApp.Models
{
    internal class Quiz
    {
        // Fields
        private static byte _id = 0;
        private string _name;

        // Properties
        public int Id { get; init; }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) _name = "New Quiz";
                else _name = value;
            }
        }
        public List<Question> Questions { get; set; }

        // Constructor
        public Quiz(string name, List<Question> questions)
        {
            Id = ++_id;
            Name = name;
            Questions = questions;
        }

        // Methods
        public void ShowQuestions()
        {
            foreach (Question question in Questions)
            {
                Console.WriteLine(question);
            }
        }
        
        public override string ToString()
        {
            return $"{Id}. {Name} | {Questions.Count} questions";
        }
    }
}
