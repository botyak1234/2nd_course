
using System;
using System.ComponentModel.Design;

class chisla
{
    static void Input(out double[][] a, int n)
    {
        Random r = new Random();
        a = new double[n][];
        for (int i = 0; i < n; i++)
        {
            a[i] = new double[n];
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                //a[i][j] = r.Next(-5, 5);
                a[i][j] = double.Parse(Console.ReadLine());
            }
        }
    }



    static void Output(double[][] a, int n, int m)
    {
        if (n != 0)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0, 2}", a[i][j]);
                }
                Console.WriteLine('\n');
            }
        }
        else Console.WriteLine("удалён весь массив");
    }



    static void deletestr(double[][] a, ref int n, double x, double y)
    {
            for (int i = 0; i < n; i++)
            {
                bool flag = true;
                for (int j = 0; j < n; j++)
                {
                    if (a[i][j] < x || a[i][j] > y)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    for (int k = i; k < n - 1; k++)
                    {
                        a[k] = a[k + 1];
                    }
                    --i;
                    --n;
                    a[n] = null;
                }
            }
    }


    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = n;
        double[][] a;
        chisla.Input(out a, n);
        chisla.Output(a, n, m);
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        chisla.deletestr(a, ref n, x, y);
        chisla.Output(a, n, m);
    }

}


