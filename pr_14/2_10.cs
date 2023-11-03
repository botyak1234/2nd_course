
using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.IO.Pipes;
using System.Reflection;
using System.Xml;

class chisla
{
    public
    struct Sgroup : IComparable<Sgroup>
    {
        string fam, name, second_name;
        int group, course;
        public double time;

        public Sgroup(string fam, string name, string second_name, int group, int course, double time)
        {
            this.name = name;
            this.fam = fam;
            this.second_name = second_name;
            this.group = group;
            this.course = course;
            this.time = time;
        }
        public int CompareTo(Sgroup obj)
        {
            if (this.time < obj.time) return -1;
            else if (this.time == obj.time) return 0;
            else return 1;
        }
        public void Show(StreamWriter fileout)
        {
            fileout.Write("{0} {1} {2} {3} {4} {5}", name, fam, second_name, group, course, time);
            fileout.WriteLine();

        }
        public void Show()
        {
            Console.Write("{0} {1} {2} {3} {4} {5}", name, fam, second_name, group, course, time);
            Console.WriteLine();
        }
    }
    static public Sgroup[] Input(ref int n) 
    {
        using (StreamReader fileIn = new StreamReader("C:\\Users\\Пользователь\\source\\repos\\help\\help\\input.txt"))
        {
            n = int.Parse(fileIn.ReadLine());
            Sgroup[] ar = new Sgroup[n];
            for (int i = 0; i < n; i++)
            {
                string[] text = fileIn.ReadLine().Split(' ');
                ar[i] = new Sgroup(text[0], text[1], text[2], int.Parse(text[3]), int.Parse(text[4]), double.Parse(text[5]));
            }
            return ar;
        }
    }

    static void Print(Sgroup[] array)
    {
        foreach (Sgroup student in array)
        {
            student.Show();
        }
    }



    static void Main()
    {
        int n = 0;
        Sgroup[] groupmates = Input(ref n);
        Array.Sort(groupmates);
        int count = 3;
        using (StreamWriter fileout = new StreamWriter("C:\\Users\\Пользователь\\source\\repos\\help\\help\\output.txt"))
        {
            groupmates[0].Show(fileout);
            for (int i = 1; i < n; i++)
            {
                if (count == 1)
                {
                    break;
                }
                else 
                {
                    if (groupmates[i].time != groupmates[i - 1].time)
                    {
                        count--;
                    }
                }
                groupmates[i].Show(fileout);
            }
        }
        Console.WriteLine(count);
    }
}
