namespace Models
{
    public abstract class Animal
    {
        public string Species { get; set; }
        public byte Age { get; set; }
        public float Weight { get; set; }

        public Animal(string species, byte age, float weight)
        {
            Species = species;
            Age = age;
            Weight = weight;
        }
    }
}
