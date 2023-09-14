
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
            if (i % 6 == 0)
            {
                a = i;
                break;
            }
        }
        for (int i = a; i < b; i += 6) Console.Write("{0} ", i);
        Console.WriteLine("Press any key to continue");
    }
}
