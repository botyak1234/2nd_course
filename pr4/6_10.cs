using System;
class chisla
{
    static void Main()
    {
        Console.Write("A = ");
        int a = int.Parse(Console.ReadLine());
        int sum = Prime_factor_min(a) + Prime_factor_max(a);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("Press any key to continue");
    }


    static int Prime_factor_min(int a)
    {
        bool flag;
        for (int i = 2; i < (int)Math.Sqrt(a)+1; i++)
        {
            if (a % i == 0)
            {
                flag = true;
                for (int j = 2; j < (int)Math.Sqrt(i) + 1; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) return i;
            }
        }
        return -1;
    }


    static int Prime_factor_max(int a)
    {
        bool flag;
        for (int i = (int)Math.Sqrt(a)+1; i >= 2; i--)
        {
            if (a % i == 0)
            {
                flag = true;
                for (int j = 2; j < (int)Math.Sqrt(i) + 1; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) return i;
            }
        }
        return -1;
    }

}
