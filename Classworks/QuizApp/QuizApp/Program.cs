using QuizApp.Exceptions;
using QuizApp.Models;

namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            MENU:
            0. Exit
            1. Create Quiz
            2. Show Quizzes
            3. Edit Quizzes -> Rename Quiz, Add Question, Edit Question (edit text, variants), Remove Question
            4. Remove Quiz
            5. Take Quiz
            */

            string mainMenu = """
                =======================
                MENU
                0 -> Quit
                1 -> Create a Quiz
                2 -> Show Quizzes
                3 -> Edit Quizzes
                4 -> Remove Quiz
                5 -> Take a Quiz
                =======================
                """;
            string editQuizMenu = """
                =======================
                MENU
                0 -> Go Back
                1 -> Rename Quiz
                2 -> Add Question
                3 -> 
                4 -> Remove Quiz
                5 -> Take a Quiz
                =======================
                """;

            #region Sample Quizzes
            List<Quiz> quizList = [];

            Variant var1 = new Variant(1, "var 1", true);
            Variant var2 = new Variant(2, "var 2", false);
            Variant var3 = new Variant(3, "var 3", false);
            Variant var4 = new Variant(4, "var 4", false);

            List<Variant> vars = [var1, var2, var3];

            Question qn1 = new Question(1, "text 1", vars);
            Question qn2 = new Question(2, "text 2", vars);
            Question qn3 = new Question(3, "text 3", vars);

            List<Question> qns = [qn1, qn2, qn3];

            Quiz quiz1 = new Quiz("Quiz 1", qns);
            Quiz quiz2 = new Quiz("Quiz 2", qns);

            quizList.AddRange([quiz1, quiz2]);
            #endregion


            string shortcut = "";

            Console.Clear();
            while (shortcut != "0")
            {
                Console.WriteLine(mainMenu);
                Console.WriteLine("Enter shortcut:");
                shortcut = Console.ReadLine();
                Console.Clear();

                switch (shortcut)
                {
                    case "0": return;
                    case "1":
                        {
                            Quiz newQuiz = CreateQuiz();
                            quizList.Add(newQuiz);
                            break;
                        }
                    case "2": { ShowQuizzes(quizList); break; }
                    case "3": { TakeQuiz(ref quizList); break; }
                    case "4": { EditQuiz(ref quizList); break; }
                    case "5":
                        {
                            RemoveQuizById(quizList, 1); // TODO: Take id from user
                            break;
                        }
                    default: { Console.WriteLine("Invalid shortcut! Try again..."); break; }
                }
            }
        }

        static Quiz CreateQuiz()
        {
            Console.WriteLine("""
                ==============
                CREATING QUIZ
                ==============
                """);

            // Take Quiz Name
            Console.WriteLine("Enter quiz name:");
            string quizName = Console.ReadLine();
            Console.Clear();

        checkpoint_1:
            // Take Count of Questions
            Console.Write("Enter number of questions:");
            if (!int.TryParse(Console.ReadLine(), out int count))
            {
                Console.Clear();
                Console.WriteLine("Not a positive integer! Try again...");
                Console.WriteLine("=====================================");
                goto checkpoint_1;
            }

            // Take Questions
            List<Question> questionList = [];
            for (int i = 0; i < count; i++)
            {
            checkpoint_2:
                // Take question text
                Console.WriteLine($"Enter question-{i + 1}:");
                string questionText = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(questionText))
                {
                    Console.Clear();
                    Console.WriteLine("Question cannot be left empty! Try again...");
                    Console.WriteLine("===========================================");
                    goto checkpoint_2;
                }

                Console.WriteLine("Attention: First variant is asummed to be correct by default!\n");

                // Take variants
                List<Variant> variantList = [];
                for (int j = 0; j < 4; j++)
                {
                checkpoint_3:
                    Console.WriteLine($"Enter variant-{j + 1}:");
                    string variantText = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(variantText))
                    {
                        Console.Clear();
                        Console.WriteLine("Variant cannot be left empty! Try again...");
                        Console.WriteLine("==========================================");
                        goto checkpoint_3;
                    }
                    variantList.Add(new Variant(j + 1, variantText));
                }

                variantList[0].IsCorrect = true;

                questionList.Add(new Question(i + 1, questionText, variantList));
                Console.Clear();
            }

            Console.Clear();
            return new Quiz(quizName, questionList);
        }

        static void ShowQuizzes(List<Quiz> quizList)
        {
            foreach (Quiz quiz in quizList)
            {
                Console.WriteLine(quiz);
            }
        }

        // TODO: Review
        static void TakeQuiz(ref List<Quiz> quizList)
        {
            Quiz quiz = GetQuizByIdFromUser(quizList);

            byte countCorrect = 0;

            foreach (Question question in quiz.Questions)
            {
                question.Print();
                Console.WriteLine("\nEnter correct variant id:");

            checkpoint:  // TODO: Finish
                if (!int.TryParse(Console.ReadLine(), out int chosenId))
                {
                    Console.WriteLine("InvalidID! Try again...");
                    goto checkpoint;
                }

                if (chosenId == 0) countCorrect++;
            }

            Console.WriteLine($"{countCorrect} correct out of {quiz.Questions.Count}");
        }


        // ADDITIONAL FUNCTIONALITY

        // TODO: Check
        static void RemoveQuizById(List<Quiz> quizList, int id)
        {
            for (int i = 0; i < quizList.Count; i++)
            {
                if (quizList[i].Id == id)
                    quizList.Remove(quizList[i]);
            }

            throw new QuizNotFoundException();
        }
        static void EditQuiz(ref List<Quiz> quizList)
        {
            Console.WriteLine("""
                =============
                EDITING QUIZ
                =============
                """);

            Quiz quiz = GetQuizByIdFromUser(quizList);
            quiz.ShowQuestions();

            // TODO
            // Get question by id
            // Show editing menu: Change name; Edit Variants.

        }
        static Quiz GetQuizByIdFromUser(List<Quiz> quizList)
        {
            // Show all quizzes
            // Get id from user
            // Find quiz with that id
            // Return it

            ShowQuizzes(quizList);

        checkpoint_1:
            // Take quiz id
            Console.WriteLine("==============");
            Console.WriteLine("Enter quiz id:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Clear();
                Console.WriteLine("Not a positive integer! Try again...");
                Console.WriteLine("=====================================");
                goto checkpoint_1;
            }

            // Get quiz and show its questions
            return GetQuizById(quizList, id);  // TODO: Might return error

        }
        static Quiz GetQuizById(List<Quiz> quizList, int id)
        {
            for (int i = 0; i < quizList.Count; i++)
            {
                if (quizList[i].Id == id) return quizList[i];
            }

            throw new QuizNotFoundException();
        }
    }
}
