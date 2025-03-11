// Task 1
// Username və password daxil olunur, username dəyəri "Admin" və password dəyəri "Admin123"-dürsə
// ekrana"Xoş gəlmisiniz!", əks halda "UserName və ya password yanlışdır!" yazısını yazdırın.

String username = Console.ReadLine();
String password = Console.ReadLine();

if (username == "Admin" && password == "Admin123")
{
    Console.WriteLine("Xoş gəlmisiniz!");
}
else
{
    Console.WriteLine("UserName və ya password yanlışdır!");
}
