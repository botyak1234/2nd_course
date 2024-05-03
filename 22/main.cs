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
        static void Main()
        {
            Graph g = new Graph("C:\\Users\\Danil\\source\\repos\\heeelp\\heeelp\\graph.txt");
            char start = 'A'; // Начальная вершина
            char end = 'E';   // Конечная вершина
            HashSet<char> intermediateNodes = new HashSet<char> { 'B', 'D' }; // Промежуточные вершины
            List<char> path = g.ShortestPath(start, end, intermediateNodes);
            foreach (char Vertex in path) Console.Write("{0} ", Vertex);
        }
    }
}
