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

                byte ans = Convert.ToByte(Console.ReadLine());

                if (variants[ans].IsTrue)
                {
                    score++;
                }

                Console.WriteLine();
            }

            Console.WriteLine("===========================");
            Console.WriteLine($"Your score is {score}");

            return score;
        }

    }
}
