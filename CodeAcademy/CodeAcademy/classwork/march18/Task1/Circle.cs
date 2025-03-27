namespace CodeAcademy.classwork.march18.Task1
{
    internal class Circle : Shape
    {
        public string Color;
        public float Area;
        public float Radius;

        public Circle(string color, float radius) : base(color)
        {
            Radius = radius;
            Area = 3 * radius * radius;
        }
    }
}
