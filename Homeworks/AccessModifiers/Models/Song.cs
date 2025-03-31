namespace Models
{
    public class Song
    {
        /*
        Song class-ı olsun. Song-un Name, Genre, Singer(agregation) prop-ları olsun. 
        Name max 100 uzunluqda set oluna bilər. Genre yalnız "Pop", "Rock", "Jazz", 
        "Techno" bu value-lardan biri ola bilər. Məsələn  "Classic" ola bilməz, yalnız 
        göstərilənlərdən biri set olunmalıdır.

        Song-un rating-ləri olsun. AddRating, GetAverageRating metodları ilə 
        funksionallıq təmin olunsun.
        */
        string[] genres = { "Pop", "Rock", "Jazz", "Techno" };

        private string _name;
        private string _genre;
        private Singer[] _singers;
        private float[] _ratings;

        public string Name
        {
            get { return _name; }
            set { if (value.Length <= 100) { _name = value; } }
        }

        public string Genre
        {
            get { return _genre; }
            set
            {
                foreach (string genre in genres)
                {
                    if (value == genre) { _genre = value; return; }
                }
                Console.WriteLine("There is no such genre!");
            }
        }

        public Singer[] Singers
        {
            get { return _singers; }
            set { if (value.Length != 0) { _singers = value; } }
        }

        // Constructor
        public Song(string name, string genre, Singer[] singers)
        {
            Name = name;
            Genre = genre;
            Singers = singers;
            _ratings = new float[0];
        }

        // Methods
        public void AddRating(float rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                Array.Resize(ref _ratings, _ratings.Length + 1);
                _ratings[^1] = rating;
            }
            else { Console.WriteLine("Rating needs to be in range [0, 10]"); }
        }

        public float GetAvgRating()
        {
            float sum = 0;
            float count = _ratings.Length;
            
            foreach (float rating in _ratings) { sum += rating; }

            //Console.WriteLine(sum);
            //Console.WriteLine(count);

            return sum / count;
        }
    }
}
