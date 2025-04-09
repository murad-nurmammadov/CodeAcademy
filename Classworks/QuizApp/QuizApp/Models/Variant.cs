namespace QuizApp.Models
{
    internal class Variant
    {
        // Fields
        public string _variantText;
        
        // Properties
        public string VariantText
        {
            get => _variantText;
            set => _variantText = value;
        }

        // Constructor
        public Variant(string text)
        {
            _variantText = text;
        }
    }
}
