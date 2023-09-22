
using System;


class chisla
{
    static void rec(int n)
    {
        if (n == 0) return;
        draw(n);
        rec(n - 1);
    }

    static void draw(int n)
    {
        for (int i = 0; i < n; i++) Console.Write('*');
        Console.WriteLine();
    }


    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        rec(n);
    }
}


    
