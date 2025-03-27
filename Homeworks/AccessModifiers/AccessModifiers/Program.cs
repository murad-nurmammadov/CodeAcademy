using Models;

namespace AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Song class-ı olsun. Song-un Name, Genre, Singer(agregation) prop-ları olsun. 
            Name max 100 uzunluqda set oluna bilər. Genre yalnız "Pop", "Rock", "Jazz", 
            "Techno" bu value-lardan biri ola bilər. Məsələn  "Classic" ola bilməz, yalnız 
            göstərilənlərdən biri set olunmalıdır.

            Song-un rating-ləri olsun. AddRating, GetAverageRating metodları ilə 
            funksionallıq təmin olunsun.
            */

            Singer singer1 = new Singer("Bruno", "Mars", 39);

            Console.WriteLine($"{singer1.Name} {singer1.Surname}");
        }
    }
}
