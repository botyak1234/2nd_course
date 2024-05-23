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
            string filein = "C:\\Users\\Danil\\source\\repos\\heeelp\\heeelp\\input.txt";
            BinaryTree help = new BinaryTree();
            using (StreamReader In = new StreamReader(filein))
            {
                string s = In.ReadLine();
                char[] chars = { ' ', '\n', '\t', '.', ',', '!', ':', '"', '\'', '\\', '/' };
                List<string> strings_ = new List<string>(s.Split(chars, StringSplitOptions.RemoveEmptyEntries));
                foreach (string obj in strings_)
                {
                    help.add(int.Parse(obj));
                }
            }
            bool Balanced = help.IsBalanced();
            int addCount = int.Parse(Console.ReadLine());
            int check;
            int c = 0;
            bool flag = false;

            while (addCount > 0)
            {
                if (help.IsBalanced())
                {
                    flag = true;
                    break;
                }
                int ADD;
                help.FindDisbalance(out ADD);
                addCount--;
                c++;
            }
            if (help.IsBalanced())
            {
                flag = true;
            }
            help.Preorder();
            Console.WriteLine();
            if (c == 0)
            {
                Console.WriteLine("Дерево уже сбалансировано, пожалуйста, оставьте дерево в покое");
            }
            else if (flag)
            {
                Console.WriteLine("Дерево было сбалансировано");
            }
            else
            {
                Console.WriteLine("Дерево не было сбалансировано");
            }
        }
    }
}
