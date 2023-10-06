
using System;
using System.ComponentModel.Design;

class chisla
{
    static void Input(out double[,] a, int n)
    {
        a = new double[n, n];
        Random r = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                //a[i, j] = r.Next(-5, 5);
                a[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }


    static void Output(double[] b, bool flag)
    {
        if (flag)
        {
            foreach (double element in b)
            {
                Console.Write("{0} ", element);
            }
        }
        else
        {
            foreach (double element in b)
            {
                if (element > 0)
                {
                    Console.Write("{0} ", element);
                    Console.Write(' ');
                }
            }
            Console.WriteLine("В некотором столбце не найдено положительное число");
        }
    }
    static void Output(double[,] a, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0, 2}", a[i, j]);
            }
            Console.WriteLine('\n');
        }
    }



    static bool find_plus(double[,] a, double[] b, int n)
    {
        bool flag_all = true;
        for (int i = 0; i < n; i++)
        {
            bool flag = false;
            for (int j = 0; j < n; j++)
            {
                if (a[j, i] > 0)
                {
                    flag = true;
                    b[i] = a[j, i];
                    break;
                }
            }
            if (!flag)
            {
                flag_all = false;
            }
        }
        return flag_all;
    }



    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double[,] a;
        chisla.Input(out a, n);
        chisla.Output(a, n);
        double[] b;
        b = new double[n];
        chisla.Output(b, find_plus(a, b, n));

    }

}


