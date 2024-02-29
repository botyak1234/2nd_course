using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.ComponentModel;
namespace heeelp
{
    class Program
    {


        static void Main()
        {
            string filein = "C:\\Users\\Danil\\source\\repos\\heeelp\\heeelp\\input.txt";
            string fileout = "C:\\Users\\Danil\\source\\repos\\heeelp\\heeelp\\output.txt";
            BinaryTree help = new BinaryTree();
            using (StreamReader In = new StreamReader(filein))
            {
                string s = In.ReadLine();
                char[] chars = { ' ', '\n', '\t', '.', ',', '!', ':', '"', '\'', '\\', '/' };
                List<string> strings_ = new List<string>(s.Split(chars, StringSplitOptions.RemoveEmptyEntries));
                foreach (string obj in strings_)
                {
                    help.Add(int.Parse(obj));
                }
            }

            int min_ = 20;

            help.Preorder();
            min_ = help.FindMin();
            Console.WriteLine();
            Console.WriteLine(min_);
        }
    }
}
//10 5 4 6 12 11 13


