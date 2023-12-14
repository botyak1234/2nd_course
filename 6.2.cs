using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;

class Programm
{
    static int IndexOf(string str1, string str2, int n)
    {
        int length1 = str1.Length;
        int length2 = str2.Length;
        int i, j;
        for (i = n; i < length1;)
        {
            if (str1[i] == str2[0])
            {
                for (j = 1; j < length2 && i + j < length1; j++)
                {
                    if (str2[j] != str1[i + j])
                    {
                        break;
                    }
                }
                if (j == str2.Length)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            else
            {
                i++;
            }
        }
        return -1;
    }
    static void Main()
    {
        using (StreamReader filein = new StreamReader("C:\\Users\\Danil\\source\\repos\\ConsoleApp1\\ConsoleApp1\\input.txt"))
        {
            string podstroka = filein.ReadLine();
            string ishodnik = filein.ReadToEnd();
            int index = 0;
            const long P = 37;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int length_podstroka = podstroka.Length;
            int length_ishodnik = ishodnik.Length;
            long[] pwp = new long[length_ishodnik];
            pwp[0] = 1;
            for (int i = 1; i < length_ishodnik; i++)
            {
                pwp[i] = pwp[i - 1] * P;
            }
            long[] h = new long[length_ishodnik];
            
            for (int i = 0; i < length_ishodnik; i++)
            {
                h[i] = (ishodnik[i] - 'a' + 1) * pwp[i]; 
                if (i > 0)
                    h[i] += h[i - 1];
            }
            long h_s = 0;
            for (int i = 0; i < length_podstroka; i++)
            {
                h_s += (podstroka[i] - 'a' + 1) * pwp[i];
            }
            for (int i = 0; i + length_podstroka - 1 < length_ishodnik; i++)
            {
                long cur_h = h[i + length_podstroka - 1];
                if (i > 0)
                {
                    cur_h -= h[i - 1];
                }
                if (cur_h == h_s * pwp[i])
                {
                    Console.WriteLine("{0} ", i);
                    break;
                }
            }

            
            
            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            
            
            timer.Start();
            index = IndexOf(ishodnik, podstroka, 0);
            timer.Stop();
            Console.WriteLine(index);
            Console.WriteLine(timer.ElapsedTicks);
        }
    }
       
}
