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
        static int CheckUzelCount(Graph g, int Uzel, List<int> array)
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
                return -1;
            }
            if (countOdd == 1)
            {
                int countCheck = 0;
                for (int i = 0; i < n; i++)
                {
                    if (g[Uzel, i] == 1) countCheck++; 
                }
                if (countCheck == 1)
                {
                    return 0;
                }
                return -1;
            }
            if (countOdd == 2)
            {
                int COUNT = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (g[i, j] != 0) COUNT++;
                    }
                    if (COUNT % 2 == 1) array.Add(i);
                    COUNT = 0;
                }
                if (g[array[0], array[1]] == 1) return 1;
                return 2;
            }
            return 1;
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



        static bool CheckSolo(List<int> array, Graph g)
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


        static bool IsConnected(Graph g)
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

        static bool IsConnected(List<int> array, Graph g)
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
            List<int> pair = new List<int>();
            List<int> array = new List<int>();
            Graph g = new Graph("C:\\Users\\Danil\\source\\repos\\heeelp\\heeelp\\graph.txt");
            if (CheckSolo(array, g))
            {
                if (CheckUzelCount(g, aUzel, pair) == -1)
                {
                    Console.WriteLine("!!!Пути не существует");
                }
                if (CheckUzelCount(g, aUzel, pair) == 0)
                {
                    if (IsConnected(array, g))
                    {
                        g.SearchG(aUzel);
                    }
                }
                if (CheckUzelCount(g, aUzel, pair) == 1)
                {
                    if (IsConnected(array, g))
                    {
                        g.SearchG(aUzel);
                    }
                }
                if (CheckUzelCount(g, aUzel, pair) == 2)
                {
                    if (IsConnected(array, g))
                    {
                        g.SearchG(aUzel, pair);
                    }
                }
            }
            else 
            {
                if (CheckUzelCount(g, aUzel, pair) == -1)
                {
                    Console.WriteLine("!!!Пути не существует");
                }
                if (CheckUzelCount(g, aUzel, pair) == 0)
                {
                    if (IsConnected(g))
                    {
                        g.SearchG(aUzel);
                    }
                }
                if (CheckUzelCount(g, aUzel, pair) == 1)
                {
                    if (IsConnected(g))
                    {
                        g.SearchG(aUzel);
                    }
                }
                if (CheckUzelCount(g, aUzel, pair) == 2)
                {
                    if (IsConnected(g))
                    {
                        g.SearchG(aUzel, pair);
                    }
                }
            }
        }
    }
}
