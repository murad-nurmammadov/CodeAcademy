﻿#region Task 1
// Verilmish ededin mertebelerinin en boyuyunu tapan alqoritm
// Misal: input 7481, output 8

//int num = Convert.ToInt32(Console.ReadLine());
//int maxDigit = 0;

//while (num > 0)
//{
//    int digit = num % 10;
//    if (digit > maxDigit)
//    {
//        maxDigit = digit;
//    }
//    num /= 10;
//}

//Console.WriteLine(maxDigit);
#endregion

#region Task2
// Verilmish ededin 2 quvveti olub olmadigini tapan alqoritm
// Misal: input 8 output 2-in quvvetidir ve ya input 9 2-in quvveti deyil

//int num = Convert.ToInt32(Console.ReadLine());
//int powerOfTwo = 1;
//bool isPowerOfTwo = false;

//while (powerOfTwo <= num)
//{
//    if (powerOfTwo == num)
//    {
//        isPowerOfTwo = true;
//        Console.WriteLine(num + " is a power of two");
//        break;
//    }
//    powerOfTwo *= 2;
//}

//if (!isPowerOfTwo)
//{
//    Console.WriteLine(num + " is NOT a power of two");
//}
#endregion

#region Task 3
// Verilmish arrayda en kicik ve en boyuk ededlerin cemini cixaran alogirthm

int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int min = nums[0];
int max = nums[0];

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] < min)
    {
        min = nums[i];
    }

    if (nums[i] > max)
    {
        max = nums[i];
    }
}

Console.WriteLine(min + max);
#endregion
