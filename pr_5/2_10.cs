
using System;

class chisla
{
    static double stepen(double x, int n)
    {
        double power = 1;
        if (x == 0) power *= x;
        else
        {
            while (n > 0)
            {
                if (n % 2 == 1) power *= x;
                x *= x;
                n /= 2;
            }
        }
        return power;
    }


    static void Main()
    {
        Console.Write("a=");
        double a = int.Parse(Console.ReadLine());
        Console.Write("b=");
        double b = int.Parse(Console.ReadLine());
        Console.Write("h=");
        int h = int.Parse(Console.ReadLine());
        int c = 1;
        double sum = 0;
        double st;
        for (double i = a; i <= b; i += h)
        {
            st = stepen(i, c);
            Console.Write(st);
            sum += st;
            c++;
            Console.Write(' ');
        }
        Console.WriteLine();
        Console.WriteLine(sum);




        for (double x = a; x <= b; x++)
        {
            for (double y = x + 1; y <= b; y++)
            {
                double z = (int)Math.Sqrt(stepen(x, 2) + stepen(y, 2));
                if (z >= a && z <= b && z!= x && z!= y && stepen(z, 2) == stepen(x, 2) + stepen(y, 2)) Console.WriteLine("{0} {1} {2}", x, y, z);
            }
        }

        int n = 1;
        int two = 2;
        while (two <= a)
        {
            n++;
            two *= 2;
        }
        Console.WriteLine(n);
    }
}


