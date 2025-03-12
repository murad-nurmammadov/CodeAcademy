#region Task 1
// Verilmish ededin mertebelerinin en boyuyunu tapan alqoritm
// Misal: input 7481, output 8

int num = Convert.ToInt32(Console.ReadLine());
int maxDigit = 0;

while (num > 0)
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
