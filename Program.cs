string input = Console.ReadLine();
string output = "";

for  (int i = 0; i < input.Length; i++)
{
    if (input[i] == 'A' || input[i] == 'a')
    {
        output += 'a';
    } 
    else
    {
        output += input[i];
    }
}

Console.WriteLine(output);
