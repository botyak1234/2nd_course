
using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

class chisla
{
    public
    struct SPoint
    {
        public double x, y, z; //поля структуры
        public SPoint(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Show(StreamWriter fileout)
        {
            fileout.Write("{0}, {1}, {2}", x, y, z);
        }
        public double Distance(SPoint obj)
        {
            return Math.Pow(this.x - obj.x, 2) + Math.Pow(this.y - obj.y, 2) + Math.Pow(this.z - obj.z, 2);
        }
    }
    static public SPoint[] Input(ref int n, ref double r) 
    {
        using (StreamReader fileIn = new StreamReader("E:\\C++\\help\\help\\input.txt")) 
        {
            n = int.Parse(fileIn.ReadLine());
            Console.WriteLine(n);
            r = double.Parse(fileIn.ReadLine());
            SPoint[] points = new SPoint[n]; 
            for (int i = 0; i < n; i++)
            {
                string[] text = fileIn.ReadLine().Split(' ');
                points[i] = new SPoint(int.Parse(text[0]), int.Parse(text[1]), int.Parse(text[2])); 
            }
            return points; 
        }
    }
    
    static void Main()
    {
        int n = 0;
        double r = 0;
        int c;
        int max_point = 0;
        int index = -1;
        SPoint[] points = Input(ref n, ref r);
        r *= r;
        for (int i = 0; i < n; i++)
        {
            c = 0;
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;
                else
                {
                    if (points[i].Distance(points[j]) <= r) c++;
                }
            }
            if (c > max_point)
            {
                max_point = c;
                index = i;
            }
        }
        Console.WriteLine(max_point);
        using (StreamWriter fileout = new StreamWriter("E:\\C++\\help\\help\\output.txt"))
        {
            if (max_point == 0) fileout.WriteLine("there is no such point");
            else points[index].Show(fileout);
        }
    }
}
