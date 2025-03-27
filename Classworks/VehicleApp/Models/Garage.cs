namespace Models
{
    public class Garage
    {
        private Vehicle[] Vehicles {  get; set; }

        public Garage(Car[] cars, Motorcycle[] motorcycles, Truck[] trucks)
        {
            Vehicles = [..cars, ..motorcycles, ..trucks];
        }
    }
}
