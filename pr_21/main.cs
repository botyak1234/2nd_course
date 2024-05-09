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
            for (int i = 0; i < addCount; i++)
            {
                int ADD;
                check = help.IsEasyToBalance();
                if (check == 0)
                {
                    help.add(0, Int32.MaxValue);
                }
                if (check == 1)
                {
                    BinaryTree ob = help.FindDisbalance(out ADD);
                    ob.add(ADD);
                    help.preorder();
                }
            }
            if (help.IsBalanced())
            {
                Console.WriteLine("Возможно");
                help.preorder();
            }
            else
            {
                Console.WriteLine("Невозможно");
            }
        }
    }
}
