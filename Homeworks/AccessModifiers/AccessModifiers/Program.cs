using Models;

namespace AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singer singer1 = new Singer("Name_1", "Surname_1", 32);
            Singer singer2 = new Singer("Name_2", "Surname_2", 27);

            //Console.WriteLine($"{singer1.Name} {singer1.Surname}, {singer1.Age}");
            
            Song song = new Song("Song", "Pop", [singer1, singer2]);

            song.AddRating(5);
            song.AddRating(13);
            song.AddRating(8);
            song.AddRating(9);
            song.AddRating(7);
            song.AddRating(8);

            Console.WriteLine(song.GetAvgRating());
        }
    }
}
