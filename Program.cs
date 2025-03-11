#region Task 1
// Username və password daxil olunur, username dəyəri "Admin" və password dəyəri "Admin123"-dürsə
// ekrana"Xoş gəlmisiniz!", əks halda "UserName və ya password yanlışdır!" yazısını yazdırın.

//String username = Console.ReadLine();
//String password = Console.ReadLine();

//if (username == "Admin" && password == "Admin123")
//{
//    Console.WriteLine("Xoş gəlmisiniz!");
//}
//else
//{
//    Console.WriteLine("UserName və ya password yanlışdır!");
//}
#endregion

#region Task 2
// Bir dəyişən təyin olunur, ədədin cüt və ya tək olduğu ekrana çap olunur

//int num = Convert.ToInt32(Console.ReadLine());

//if (num == 0)
//{
//    Console.WriteLine("Neither odd, nor even");
//}
//else if (num % 2 == 0)
//{
//    Console.WriteLine("Even");
//}
//else
//{
//    Console.WriteLine("Odd");
//}
#endregion

#region Task 3
// 2 ədəd daxil olunur, əgər ədədlərin hər ikisi 2'yə qalıqsız bölünürsə, cəmini
// tapırsınız, əks halda ekrana "daxil olunan ədədlər cüt olmalıdır!" yazısını yazdırırsınız.

//int num1 = Convert.ToInt32(Console.ReadLine());
//int num2 = Convert.ToInt32(Console.ReadLine());

//if (num1 % 2 == 0 && num2 % 2 == 0)
//{
//    Console.WriteLine(num1 + num2);
//}
//else
//{
//    Console.WriteLine("daxil olunan ededler cut olmalidir!");
//}
#endregion

#region Task 4
// Tələbə balını daxil edir, bu bala uyğun, hərf balı tapırsınız.
// (Məsələn: 91 -> A, 75 -> C)

//int score = Convert.ToInt32(Console.ReadLine());

//if (score > 100 || score < 0)
//{
//    Console.WriteLine("Invalid score");
//}
//else if (score >= 91)
//{
//    Console.WriteLine("A");
//}
//else if (score >= 81)
//{
//    Console.WriteLine("B");
//}
//else if (score >= 71)
//{
//    Console.WriteLine("C");
//}
//else if (score >= 61)
//{
//    Console.WriteLine("D");
//}
//else if (score >= 51)
//{
//    Console.WriteLine("E");
//}
//else
//{
//    Console.WriteLine("F");
//}
#endregion

#region Task 5
// A,B,C rəqəmləri verilib, 5 ə tam bölünənlərin cəmini ekrana çıxardın.

//int a = Convert.ToInt32(Console.ReadLine());
//int b = Convert.ToInt32(Console.ReadLine());
//int c = Convert.ToInt32(Console.ReadLine());

//int sum = 0;

//if (a % 5 == 0) { sum += a; }

//if (b % 5 == 0) { sum += b; }

//if (c % 5 == 0) { sum += c; }

//Console.WriteLine(sum);
#endregion

#region Task 6
// Verilmiş 2 mərtəbəli ədədin hansı mərtəbə vahidinin daha böyük olduğunu tapın

int num = Convert.ToInt32(Console.ReadLine());

int maxDigit = num % 10;

while (num != 0)
{
    int digit = num % 10;
    if (digit > maxDigit) 
    { 
        maxDigit = digit;
    }
    num /= 10;
}

Console.WriteLine(maxDigit);
#endregion
