namespace Models
{
    public class Song
    {
        public string Name;
        public string Genre;
        public Singer[] Singers;
        public float Rating;

        static string[] genres = { "Pop", "Rock", "Jazz", "Techno" };

        public Song(string name, string genre, Singer[] singers)
        {
            if (name.Length > 100)
            {
                throw new Exception("Song name length cannot exceed 100!");
            }
            if (!genres.Contains(genre)) {
                throw new Exception("Invalid genre!");
            }

            Name = name;
            Genre = genre;
            Singers = singers;
        }


    }
}
