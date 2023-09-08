using System;
class cub{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int sum = b % 10 + b / 100 + b / 10 % 10;
        string x = sum % a == 0? "да":"нет";
        Console.WriteLine(x);
    }
}