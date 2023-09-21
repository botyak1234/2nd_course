
using System;
using System.ComponentModel.Design;

class chisla
{
    static double rec(double x, int i, int n)
    {
        if (i == n) return x/(n+x);
        return x / (i + rec(x, i + 1, n));
    }




    static void Main()
    {
        Console.Write("x =");
        double x = int.Parse(Console.ReadLine());
        Console.Write("n =");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(rec(x, 1, n));
    }
}


    
