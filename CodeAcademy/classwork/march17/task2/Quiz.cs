namespace CodeAcademy.classwork.march17.task2
{
    internal class Quiz
    {
        public Question[] Questions;

        public Quiz(Question[] questions)
        {
            Questions = questions;
        }

        public void Print()
        {
            foreach (Question question in Questions)
            {
                Console.WriteLine(question.Text);

                foreach (Variant variant in question.Variants)
                {
                    if (variant.IsTrue)
                    {
                        Console.WriteLine($"{variant.Text} -- True");
                    }
                    else
                    {
                        Console.WriteLine(variant.Text);
                    }
                }
            }
        }

        public int Play()
        {
            int score = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                Question qn = Questions[i];
                Variant[] variants = qn.Variants;

                Console.WriteLine(qn.Text);
                for (int j = 0; j < variants.Length; j++)
                {
                    Console.WriteLine($"{j}) {variants[j].Text}");
                }

                bool correctAnswer = false;

                while (!correctAnswer)
                {
                    try
                    {
                        byte ans = Convert.ToByte(Console.ReadLine());

                        if (ans >= 0 && ans < variants.Length)
                        {
                            correctAnswer = true;

                            if (variants[ans].IsTrue)
                            {
                                score++;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid answer. Enter number between 0 and {variants.Length-1}:");
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid answer. Enter number between 0 and {variants.Length-1}:");
                    }

                }

                Console.WriteLine();
            }

            Console.WriteLine("===========================");
            Console.WriteLine($"Your score is {score}");

            return score;
        }

    }
}
