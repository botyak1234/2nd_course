using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections;
namespace heeelp
{
    public class Graph
    {
        private class Node //вложенный класс для скрытия данных и алгоритмов
        {
            private int[,] array; //матрица смежности
            public int this[int i, int j] //индексатор для обращения к матрице смежности
            {
                get
                {
                    return array[i, j];
                }
                set
                {
                    array[i, j] = value;
                }
            }
            public int Size //свойство для получения размерности матрицы смежности
            {
                get
                {
                    return array.GetLength(0);
                }
            }
            public bool[] nov; //вспомогательный массив: если i-ый элемент массива равен
                                //true, то i-ая вершина еще не просмотрена; если i-ый
                                //элемент равен false, то i-ая вершина просмотрена
            public void NovSet() //метод помечает все вершины графа как непросмотреные
            {
                for (int i = 0; i < Size; i++)
                {
                    nov[i] = true;
                }
            }
            //конструктор вложенного класса, инициализирует матрицу смежности и
            // вспомогательный массив
            public Node(int[,] a)
            {
                array = a;
                nov = new bool[a.GetLength(0)];
            }
            //реализация алгоритма обхода графа в глубину

            public void Dfs(int v)
            {
                nov[v] = false; //помечаем ее как просмотренную
                                // в матрице смежности просматриваем строку с номером v
                for (int u = 0; u < Size; u++)
                {
                    //если вершины v и u смежные, к тому же вершина u не просмотрена,
                    if (array[v, u] != 0 && nov[u])
                    {
                        Dfs(u); // то рекурсивно просматриваем вершину
                    }
                }
            }
            //реализация алгоритма обхода графа в ширину
            public void Bfs(int v)
            {
                Queue q = new Queue(); // инициализируем очередь
                q.Enqueue(v); //помещаем вершину v в очередь
                nov[v] = false; // помечаем вершину v как просмотренную
                while (q.Count != 0) // пока очередь не пуста
                {
                    v = (int)q.Dequeue(); //извлекаем вершину из очереди
                    for (int u = 0; u < Size; u++) //находим все вершины
                    {
                        if (array[v, u] != 0 && nov[u]) // смежные с данной и еще не просмотренные
                        {
                            q.Enqueue(u); //помещаем их в очередь
                            nov[u] = false; //и помечаем как просмотренные
                        }
                    }
                }
            }

            public void SearchG(int v, ref int[,] a, ref Stack c) //во вложенном классе
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[v, i] != 0)
                    {
                        a[v, i] = 0; a[i, v] = 0;
                        SearchG(i, ref a, ref c);
                    }
                }
                c.Push(v);
            }

            public List<char> Dijkstra(char start, char end, HashSet<char> intermediateNodes)
            {
                Dictionary<char, int> distances = new Dictionary<char, int>();
                Dictionary<char, char> previous = new Dictionary<char, char>();
                HashSet<char> visited = new HashSet<char>();
                int numVertices = Size;
                for (int i = 0; i < numVertices; i++)
                {
                    distances[(char)('A' + i)] = int.MaxValue;
                    previous[(char)('A' + i)] = '\0';
                }

                distances[start] = 0;
                Queue<char> queue = new Queue<char>();
                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    char current = queue.Dequeue();

                    if (current == end)
                        break;

                    if (visited.Contains(current))
                        continue;

                    visited.Add(current);

                    int currentVertexIndex = current - 'A';
                    
                    if (intermediateNodes.Contains(current))
                    {
                        for (int i = 0; i < numVertices; i++)
                        {
                            char neighbor = (char)('A' + i);
                            if (array[currentVertexIndex, i] != 0)
                            {
                                int newDistance = distances[current] + array[currentVertexIndex, i];
                                distances[neighbor] = newDistance;
                                previous[neighbor] = current;
                                queue.Enqueue(neighbor);
                            }
                        }
                    }

                    for (int i = 0; i < numVertices; i++)
                    {
                        char neighbor = (char)('A' + i);
                        if (array[currentVertexIndex, i] != 0)
                        {
                            int newDistance = distances[current] + array[currentVertexIndex, i];
                            if (newDistance < distances[neighbor])
                            {
                                distances[neighbor] = newDistance;
                                previous[neighbor] = current;
                                queue.Enqueue(neighbor);
                            }
                        }
                    }
                }

                List<char> path = new List<char>();

                char v = end;
                while (v != '\0')
                {
                    path.Add(v);
                    v = previous[v];
                }

                // Reverse the path
                path.Reverse();

                return path;
            }
        }

      


        private Node graph; //закрытое поле, реализующее АТД «граф»

       
        public Graph(string name) //конструктор внешнего класса
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine());
                int[,] a = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }
                graph = new Node(a);
            }
        }
        //метод выводит матрицу смежности на консольное окно
        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write("{0,4}", graph[i, j]);
                }
                Console.WriteLine();
            }
        }


        public void Dfs(int v)
        {
            graph.NovSet();//помечаем все вершины графа как непросмотренные
            graph.Dfs(v); //запускаем алгоритм обхода графа в глубину
        }
        public void Bfs(int v)
        {
            graph.NovSet();//помечаем все вершины графа как непросмотренные
            graph.Bfs(v); //запускаем алгоритм обхода графа в ширину
        }

        public int Size()
        {
            return graph.Size;
        }

        public bool[] NovList()
        {
            return graph.nov;
        }

        public int this[int i, int j]
        {
            get 
            {
                return (int)graph[i, j];
            }
        }
            
         

        public void SearchG(int aUzel) //во внешнем классе
        {
            int[,] a = new int[graph.Size, graph.Size];
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    a[i, j] = graph[i, j];
                }
            }
            Stack c = new Stack();
            graph.SearchG(aUzel, ref a, ref c);
            while (c.Count != 0)
            {
                Console.Write("{0} ", (int)c.Pop() + 1);
            }
        }

        public void SearchG(int aUzel, List<int> pair) //во внешнем классе
        {
            int[,] a = new int[graph.Size, graph.Size];
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    a[i, j] = graph[i, j];
                }
            }
            Stack c = new Stack();
            graph.SearchG(aUzel, ref a, ref c);
            while (c.Count != 0)
            {
                Console.Write("{0} ", (int)c.Pop() + 1);
            }
        }

        public List<char> ShortestPath(char start, char end, HashSet<char> intermediateNodes)
        {
            return graph.Dijkstra(start, end, intermediateNodes);
        }
    }
}
