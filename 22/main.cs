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
        static int distance((string, int, int) a, (string, int, int) b)
        {
            return (int)Math.Sqrt(Math.Pow(a.Item2 - b.Item2, 2) + Math.Pow(a.Item3 - b.Item3, 2));
        }

        static int GetKeyByValue(Dictionary<int, (string, int, int)> dictionary, string value)
        {
            if (dictionary.Any(x => x.Value.Item1 == value))
            {
                var item = dictionary.Single(x => x.Value.Item1 == value);
                return item.Key;
            }
            else
            {
                Console.WriteLine("Value not found");
                return -1;
            }
        }



        static void Main()
        {
            var cities = new Dictionary<int, (String, int, int)>();
            string[] lines = File.ReadAllLines("C:\\Users\\Пользователь\\source\\repos\\help\\help\\graph.txt");
            int n = int.Parse(lines[0]);
            int[,] distances = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] cityData = lines[i+1].Split();
                string name = cityData[0];
                int x = int.Parse(cityData[1]);
                int y = int.Parse(cityData[2]);
                cities[i] = (name, x, y);
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} {1} {2}", cities[i].Item1, cities[i].Item2, cities[i].Item3);
                Console.WriteLine();
            }
            for (int i = n + 1; i < lines.Length; i++)
            {
                string[] row = lines[i].Split();
                for (int j = 0; j < n; j++)
                {
                    if (row[j] == "1")
                        distances[i - n - 1, j] = distance(cities[i - n - 1], cities[j]);
                    else if (i - n - 1 != j)
                        distances[i - n - 1, j] = int.MaxValue;
                    Console.WriteLine($"{i-n-1} {j}");
                }
            }

            Console.WriteLine("Матрица смежности:");
            Console.Write("\t");
            for (int i = 0; i < n; i++)
                Console.Write($"{cities[i].Item1}\t");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{cities[i].Item1}\t");
                for (int j = 0; j < n; j++)
                {

                    if (distances[i, j] == int.MaxValue)
                        Console.Write("0\t");
                    else
                        Console.Write($"{(distances[i, j])}\t");
                }
                Console.WriteLine();
            }

            Graph g = new Graph(distances);
            int start = GetKeyByValue(cities, Console.ReadLine()); 
            int end = GetKeyByValue(cities, Console.ReadLine());
            string line = Console.ReadLine();
            List<string> towns = line.Split().ToList();
            List<int> townsint = new List<int>();
            foreach (string item in towns)
            {
                townsint.Add(GetKeyByValue(cities, item));
            }
            List<string> path = g.Dijkstr(start, end, townsint);
            if (path.Count == 0)
            {
                Console.WriteLine("Пути не существует");
            }
            else
            {
                Console.WriteLine($"Кратчайший путь от {cities[start].Item1} до {cities[end].Item1}");
                foreach (string item in path)
                {
                    Console.Write($"{cities[int.Parse(item)].Item1} ");
                }
            }
        }

    }
}
