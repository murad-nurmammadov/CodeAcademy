namespace CodeAcademy.classwork.march18.Task1
{
    internal class Shape
    {
        public string Color;
        public float Area;

        public Shape(string color)
        {
            Color = color;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{Color} {Area}");
        }
    }
}
