namespace QuizApp.Models
{
    internal class Question
    {
        // Properties
        public int Id { get; init; }
        public string Text { get; set; }
        public List<Variant> Variants { get; set; }

        // Constructor
        public Question(int id, string text, List<Variant> variants)
        {
            Id = id;
            Text = text;
            Variants = variants;
        }

        // Methods
        public void Print()
        {
            Console.WriteLine("=======================");
            Console.WriteLine($"{Id}. {Text}");
            Console.WriteLine("-----------------------");
            foreach(var variant in Variants )
            {
                Console.WriteLine(variant);
            }
        }

        public override string ToString()
        {
            string correctAsnwer = "";

            foreach (var variant in Variants)
            {
                if (variant.IsCorrect == true)
                {
                    correctAsnwer = variant.Text;
                }
            }

            return $"{Id}. {Text} | Answer: {correctAsnwer}";
        }
    }
}
