using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class Programm
{
    public
    struct Stuff
    {
        public string surname, name, middle_name, post;
        public int year, experience;
        public double salary;

        public Stuff(string surname, string name, string middle_name, string post, int year, int experience, double salary)
        {
            this.surname = surname;
            this.name = name;
            this.middle_name = middle_name;
            this.post = post;
            this.year = year;
            this.experience = experience;
            this.salary = salary;
        }
    }



    static public Stuff[] Input(ref int n)
    {
        using (StreamReader fileIn = new StreamReader("C:\\Users\\contest\\source\\repos\\ConsoleApp2\\ConsoleApp2\\input1.txt"))
        {
            n = int.Parse(fileIn.ReadLine());
            Stuff[] stuffs = new Stuff[n];
            for (int i = 0; i < n; i++)
            {
                string[] text = fileIn.ReadLine().Split(' ');
                stuffs[i] = new Stuff(text[0], text[1], text[2], text[3], int.Parse(text[4]), int.Parse(text[5]), double.Parse(text[6]));
            }
            return stuffs;
        }
    }




    static void Main()
    {
        int n = 0;
        Stuff[] stuffs = Input(ref n);
        var query = from member in stuffs
                    group member by member.post;
        using (StreamWriter fileout = new StreamWriter("C:\\Users\\contest\\source\\repos\\ConsoleApp2\\ConsoleApp2\\output1.txt", false))
        {
            foreach (var items in query)
            {
                fileout.Write("{0}: ", items.Key);
                fileout.WriteLine();
                foreach (var item in items)
                {
                    fileout.Write("{0} {1} {2}", item.surname, item.name, item.middle_name);
                    fileout.WriteLine();
                }
                fileout.WriteLine();
            }
        }
        //int n = 0;
        //Stuff[] stuffs = Input(ref n);
        //var query = stuffs.GroupBy(members => members.post);
        //using (StreamWriter fileout = new StreamWriter("C:\\Users\\contest\\source\\repos\\ConsoleApp2\\ConsoleApp2\\output1.txt", false))
        //{
        //    foreach (var items in query)
        //    {
        //        fileout.Write("{0}: ", items.Key);
        //        fileout.WriteLine();
        //        foreach (var item in items)
        //        {
        //            fileout.Write("{0} {1} {2}", item.surname, item.name, item.middle_name);
        //            fileout.WriteLine();
        //        }
        //        fileout.WriteLine();
        //    }
        //}
    }
}
