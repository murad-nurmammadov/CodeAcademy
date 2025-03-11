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

int num = Convert.ToInt32(Console.ReadLine());

if (num == 0)
{
    Console.WriteLine("Neither odd, nor even");
}
else if (num % 2 == 0)
{
    Console.WriteLine("Even");
}
else
{
    Console.WriteLine("Odd");
}
#endregion



