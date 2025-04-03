namespace Models
{
    public class Bird : Animal
    {
        public bool CanFly { get; set; }

        public Bird(string species, byte age, float weight, bool canFly) : base(species, age, weight)
        {
            CanFly = canFly;
        }

        public override string ToString()
        {
            string flyInfo = CanFly ? "can fly" : "cannot fly";
            return $"{Species}: {Age} y.o., weighs {Weight}, {flyInfo}";
        }
    }
}
