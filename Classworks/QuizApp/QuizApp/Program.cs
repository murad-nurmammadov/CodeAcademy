using QuizApp.Models;

namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Menyunun elementləri 
            1. Create new quiz
            2. Solve a quiz
            3. Show quizzes
            0.  Quit
            */

            #region Sample Quizzes
            List<Quiz> Quizzes = new List<Quiz>();

            Variant var1 = new Variant("var 1");
            Variant var2 = new Variant("var 2");
            Variant var3 = new Variant("var 3");
            Variant var4 = new Variant("var 4");

            List<Variant> vars = new List<Variant>();

            Question qn1 = new Question("text 1", vars, 1);
            Question qn2 = new Question("text 2", vars, 2);
            Question qn3 = new Question("text 3", vars, 3);

            List<Question> qns = new List<Question>();

            Quiz quiz1 = new Quiz("Quiz 1", qns);
            Quiz quiz2 = new Quiz("Quiz 2", qns);

            Quizzes.AddRange([quiz1, quiz2]);
            #endregion


            string shortcut = "";

            while (shortcut != "0")
            {
                Console.WriteLine("====================");
                Console.WriteLine("MENU");
                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Create Quiz");
                Console.WriteLine("2. Solve a Quiz");
                Console.WriteLine("3. Show Quizzes");
                Console.WriteLine("====================");
                Console.WriteLine("Enter shortcut:");

                shortcut = Console.ReadLine();
                Console.Clear();

                switch (shortcut)
                {
                    case "0": return;
                    case "1":
                        {
                            // Quiz name
                            Console.WriteLine("Enter quiz name:");
                            string quizName = Console.ReadLine();

                            // Questions
                            Console.WriteLine("Enter number of questions:");
                            uint count = uint.Parse(Console.ReadLine());

                            List<Question> questions = new List<Question>();

                            for (int i = 0; i < count; i++)
                            {
                                Question newQuestion = _createQuestion();
                                questions.Add(newQuestion);
                                Console.Clear();
                            }

                            Quiz quiz = new Quiz(quizName, questions);
                            Quizzes.Add(quiz);
                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("Which quiz do you want to take? (Enter Id)");
                            byte quizId = byte.Parse(Console.ReadLine());
                            Quiz quiz = Quizzes[quizId];

                            byte countCorrect = 0;

                            foreach (Question question in quiz.Questions)
                            {
                                Console.WriteLine(question);

                                Console.WriteLine("Enter correct id:");
                                byte chosenId = byte.Parse(Console.ReadLine());

                                if (chosenId == question.CorrectVariantId) countCorrect++;
                            }

                            Console.WriteLine($"{countCorrect} corrects out of {quiz.Questions.Count}");
                            break;
                        }
                    case "3": { ShowQuizzes(Quizzes); break; }
                }
            }
        }

        static private Question _createQuestion()
        {
            Console.WriteLine("Enter question text:");
            string questionText = Console.ReadLine();

            List<Variant> variants = _createVariants();

            Console.WriteLine("Enter id of correct variant:");
            byte correctVarId = byte.Parse(Console.ReadLine());

            return new Question(questionText, variants, correctVarId);
        }

        static private List<Variant> _createVariants()
        {
            List<Variant> variants = new List<Variant>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Enter text of variant {i + 1}:");
                string variantText = Console.ReadLine();
                variants.Add(new Variant(variantText));
            }
            return variants;
        }

        static void ShowQuizzes(List<Quiz> quizzes)
        {
            foreach (var quiz in quizzes)
            {
                Console.WriteLine(quiz);
            }
        }
    }
}
