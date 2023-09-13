
using System;
class chisla
{
    static void Main()
    {
        Console.Write("A = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("B = ");
        int b = int.Parse(Console.ReadLine());
        for (int i = a; i < b; i++)
        {
            if (i % 3 == 0)
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine("Press any key to continue");
    }
}