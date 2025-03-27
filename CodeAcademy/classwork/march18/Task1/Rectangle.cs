namespace CodeAcademy.classwork.march18.Task1
{
    internal class Rectangle : Shape
    {
        public string Color;
        public float Area;
        public float Length;
        public float Width;

        public Rectangle(string color, float height, float width) : base(color)
        {
            Length = height;
            Width = width;
            Area = Length * Width;
        }
    }
}
