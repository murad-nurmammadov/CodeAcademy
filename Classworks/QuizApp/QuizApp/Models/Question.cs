using System.Text;

namespace QuizApp.Models
{
    internal class Question
    {
        // Fields
        public string QuestionText;

        // Properties
        public List<Variant> Variants { get; set ; }
        public byte CorrectVariantId;

        // Constructor
        public Question(string questionText, List<Variant> variants, byte correctVariantId)
        {
            QuestionText = questionText;
            Variants = variants;
            CorrectVariantId = correctVariantId;
        }
    }
}
