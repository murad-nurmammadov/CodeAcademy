namespace QuizApp.Models
{
    internal class Variant
    {
        // Properties
        public int Id { get; init; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        // Constructor
        public Variant(int id, string text, bool isCorrect = false)
        {
            Id = id;
            Text = text;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return $"{Id}. {Text}";
        }
    }
}
