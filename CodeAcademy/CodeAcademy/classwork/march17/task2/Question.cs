namespace CodeAcademy.classwork.march17.task2
{
    internal class Question
    {
        public string Text;
        public Variant[] Variants;

        public Question(string questionText, Variant[] variants)
        {
            Text = questionText;
            
            Variants = new Variant[variants.Length];
            for (int i = 0; i < variants.Length; i++)
            {
                Variants[i] = variants[i];
            }
        }
    }
}
