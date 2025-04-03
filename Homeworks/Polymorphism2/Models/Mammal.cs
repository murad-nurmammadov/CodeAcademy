namespace Models
{
    public class Mammal : Animal
    {
        public bool HasFur {  get; set; }

        public Mammal(string species, byte age, float weight, bool hasFur) : base(species, age, weight)
        {
            HasFur = hasFur;
        }

        public override string ToString()
        {
            string furInfo = HasFur ? "has fur" : "doesn't have fur";
            return $"{Species}: {Age} y.o., weighs {Weight}, {furInfo}";
        }
    }
}
