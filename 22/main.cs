using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using heeelp;
using System.Drawing;
namespace heeelp
{
    class Program
    {
        static bool CheckUzelCount(Graph g)
        {
            int n = g.Size();
            bool flag = true;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (g[i, j] != 0) count1 ++;
                    if (g[j, i] != 0) count2 ++;
                }
                if (count1 != count2)
                {
                    flag = false;
                    break;
                }
                count1 = 0;
                count2 = 0;
            }
            return flag;
        }

        static bool CheckFalse(bool[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == true) return false;
            }
            return true;
        }


        static bool IsStronglyConnected(Graph g)
        {
            int n = g.Size();
            for(int i = 0; i < n; i++)
            {
                g.Dfs(i);
                if(!CheckFalse(g.NovList())) return false;
            }
            return true;
        }

        static void Main()
        {
            int aUzel = int.Parse(Console.ReadLine());
            Graph g = new Graph("C:\\Users\\Danil\\source\\repos\\heeelp\\heeelp\\graph.txt");
            if (CheckUzelCount(g))
            {
                if (IsStronglyConnected(g))
                {
                    g.SearchG(aUzel);
                }
                else
                {
                    Console.WriteLine("Пути не существует");
                }
            }
            else
            {
                Console.WriteLine("Пути не существует");
            }
            
        }
    }
}
