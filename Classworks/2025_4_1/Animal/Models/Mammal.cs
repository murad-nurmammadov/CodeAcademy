namespace Models
{
    public class Mammal : Animal
    {
        public bool HasFur { get; set; }

        public Mammal(string name, byte age, float weight, bool hasFur) : base(name, age, weight)
        {
            HasFur = hasFur;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Species}, {Age} y.o. | {Weight} kg | {HasFur}");
        }
    }
}
