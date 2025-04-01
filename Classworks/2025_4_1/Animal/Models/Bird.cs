namespace Models
{
    public class Bird : Animal
    {
        public bool CanFly { get; set; }

        public Bird(string name, byte age, float weight, bool canFly) : base(name, age, weight)
        {
            CanFly = canFly;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Species}, {Age} y.o. | {Weight} kg | {CanFly}");
        }
    }
}
