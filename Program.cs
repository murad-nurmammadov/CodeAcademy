using CodeAcademy.classwork.march17.task1;
using CodeAcademy.classwork.march17.task2;

namespace CodeAcademy
{
    class Porgram()
    {
        static void Main()
        {
            // Task 1
            //Person murad = new Person("Murad", 20, "mathematician");
            //murad.Introduce();

            // Task 2

            Variant var1 = new Variant("variant1", true);
            Variant var2 = new Variant("variant2", false);
            Variant var3 = new Variant("variant3", false);

            Question qn1 = new Question("Text of question 1", [var1, var2, var3]);

            Question[] questions =
            {
                new Question("Text of question 1", [new Variant("variant1.1", true), 
                                                    new Variant("variant1.2", false),
                                                    new Variant("variant1.3", false)]),
                new Question("Text of question 2", [new Variant("variant2.1", false),
                                                    new Variant("variant2.2", true),
                                                    new Variant("variant2.3", false)]),
                new Question("Text of question 3", [new Variant("variant3.1", false),
                                                    new Variant("variant3.2", false),
                                                    new Variant("variant3.3", true)])
            };

            Quiz quiz = new Quiz(questions);

            //quiz.Print();
            quiz.Play();
        }
    }
}