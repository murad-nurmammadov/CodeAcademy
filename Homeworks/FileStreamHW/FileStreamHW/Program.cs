using Newtonsoft.Json;

namespace FileStreamHW
{
    internal class Program
    {
        const string filePath = @"C:\Users\99450\Projects\BB104\Homeworks\FileStreamHW\FileStreamHW\names.json";

        static void Main(string[] args)
        {
            /*
            List<string> yaradırsınız. Bunu names.json adlı jsona yazırsınız.
            void Add(string name)
            void Delete(int index)
            Metodlarını adlarına uyğun olaraq yazın.
            Əlavə olaraq ayrı-ayrılıqda böyük hərflə başlayan, ədədlə bitən, uzunluğu 5ə bərabər olan stringləri lambda expressionla yazıb ekrana verin
            */

            List<string> nameList = ["murad", "davud", "Said"];

            //if (!File.Exists(filePath))
            //{
            //    using StreamWriter sw = new(filePath);
            //    sw.Write(JsonConvert.SerializeObject(nameList));
            //}

            using (StreamWriter sw = new(filePath))
                sw.Write(JsonConvert.SerializeObject(nameList));

            Console.WriteLine($"BEFORE: {ReadJSON(filePath)}");

            Add("Yusuf");
            Add("Ruslan1");
            Add("Ali2");
            Delete(3);

            nameList = JsonConvert.DeserializeObject<List<string>>(ReadJSON(filePath));

            nameList
                .FindAll(name => char.IsUpper(name[0]))
                .ForEach(name => Console.WriteLine(name));

            nameList
                .FindAll(name => char.IsDigit(name[^1]))
                .ForEach(name => Console.WriteLine(name));
            
            nameList
                .FindAll(name => name.Length == 5)
                .ForEach(name => Console.WriteLine(name));
        }

        static string ReadJSON(string filePath)
        {
            using (StreamReader sr = new(filePath))
            {
                return sr.ReadToEnd();
            }
        }

        static void Add(string name)
        {
            string json = ReadJSON(filePath);
            using (StreamWriter sw = new(filePath))
            {
                List<string> nameList = JsonConvert.DeserializeObject<List<string>>(json);
                nameList.Add(name);
                sw.Write(JsonConvert.SerializeObject(nameList));
            }

            Console.WriteLine($"AFTER ADD: {ReadJSON(filePath)}");
        }

        static void Delete(int index)
        {
            string json = ReadJSON(filePath);
            using (StreamWriter sw = new(filePath))
            {
                List<string> nameList = JsonConvert.DeserializeObject<List<string>>(json);
                if (index < 0 || index > nameList.Count)
                {
                    Console.WriteLine("Index is out of range!");
                    return;
                }
                nameList.RemoveAt(index);
                sw.Write(JsonConvert.SerializeObject(nameList));
            }

            Console.WriteLine($"AFTER REMOVE: {ReadJSON(filePath)}");
        }
    }
}
