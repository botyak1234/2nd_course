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
            int countNode = 0;
            int countOdd = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (g[i, j] != 0) countNode++;
                }
                if (countNode % 2 != 0)
                {
                    countOdd++;
                }
                countNode = 0;
            }
            if (countOdd > 2)
            {
                return false;
            }
            return true;
        }

        static bool CheckFalse(bool[] array, Graph g)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == true)
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckFalse(List<int> help, bool[] array, Graph g)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == true)
                {
                    if (help.IndexOf(i) == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        static bool CheckSolo(List<int >array, Graph g)
        {
            int n = g.Size();
            for (int i = 0; i < n; i++)
            {
                bool flag = true;
                for (int j = 0; j < n; j++)
                {
                    if (g[i, j] == 1)
                    { 
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    array.Add(i);
                }
            }
            if (array.Count != 0)
            {
                return true;
            }
            return false;
        }


        static bool IsStronglyConnected(Graph g)
        {
            int n = g.Size();

            for (int i = 0; i < n; i++)
            {
                g.Dfs(i);
                if (!CheckFalse(g.NovList(), g))
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsStronglyConnected(List<int> array, Graph g)
        {
            int n = g.Size();
            for (int i = 0; i < n; i++)
            {
                if (array.IndexOf(i) == -1)
                {
                    g.Dfs(i);
                    if (CheckFalse(array, g.NovList(), g))
                    {
                        return true;
                    }
                }
                else continue;
            }
            return true;
        }

        static void Main()
        {
            int aUzel = int.Parse(Console.ReadLine());
            List<int> array = new List<int>();
            Graph g = new Graph("C:\\Users\\contest\\source\\repos\\ConsoleApp5\\ConsoleApp5\\graph.txt");
            if (CheckSolo(array, g))
            {
                if (CheckUzelCount(g))
                {
                    if (IsStronglyConnected(array, g))
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
            else 
            {
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
}
