namespace CodeAcademy.homeworks.march17
{
    class Student
    {
        /*
        Student classi yaradirsiz. Name, Surname, Group, Point, isGraduated (mezun olub olmadigi 
        ile bagli boolean bir type olacaq) field-leri olacaq. Student classindan instance alindigi 
        zaman isGraduated-den bashqa bütün dəyərləri ötürülməlidir. isGraduated constructor işə 
        düşdükdə gelen Point field-nə əsasən təyin olunmalıdır(65-den aşagidirsa kesilib).
        */

        public string Name;
        public string Surname;
        public string Group;
        public int Score;
        public bool IsGraduated;

        public Student(string name, string surnamge, string group, int score)
        {
            Name = name;
            Surname = surnamge;
            Group = group;
            Score = score;
            IsGraduated = (score < 65) ? false : true;
        }

        /*
        Student classinda aşağıdakı methodlari yazırsız:
            a) Getİnfo() - Studentin butun deyerlerini consola cixardan bir method.
            b) CheckGraduation() - Student-in mezun olub olmadigini(isGraduated-fieldine esasen) 
                                   ekrana cixaran method. Eger mezun olubsa bu telebe mezun olub 
                                   deye yazilsin, eger mezun olmayibsa mezun olmadigi ile bagli 
                                   bir melumat yazilsin.
            c) GetDiplomDegree() - Studentin Point-nə əsasən diplom növünü ekrana çıxaran method.
                                   Eger 65-den kicikdirse yoxdur, 65-80 araligindadirsa adi, 80-90 
                                   araligindadirsa şərəf, 90-dan yuxaridirsa yüksək şərəf.
         */

        public void GetInfo()
        {
            Console.WriteLine($"{Name} {Surname} {Group}");

            if (IsGraduated) { Console.WriteLine($"score: {Score} -> graduated"); }
            else { Console.WriteLine($"score: {Score} -> failed"); }
        }

        public void CheckGeaduation()
        {
            if (IsGraduated) { Console.WriteLine("Bu telebe mezun olub"); }
            else { Console.WriteLine("Bu telebe mezun olmayib"); }
        }

        public void GetDiplomDegree()
        {
            if (Score < 65 ) { Console.WriteLine("No diploma"); }
            else if (Score <= 80) { Console.WriteLine("Adi diploma"); }
            else if (Score <= 90) { Console.WriteLine("Sharaf diploma"); }
            else { Console.WriteLine("Yuksek sheref diploma"); }
        }
    }
}
