namespace Models
{
    public class Vehicle
    {
        public string Company { get; set; }
        public string Model { get; set; }
        public ushort Year { get; set; }

        public Vehicle(string company, string model, ushort year)
        {
            Company = company;
            Model = model;
            Year = year;
        }
    }
}
