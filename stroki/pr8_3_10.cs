using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq.Expressions;

class chisla
{



    static void Main()
    {
        int count = 0;
        string s = Console.ReadLine();
        List<string> strings_ = new List<string>(s.Split());
        foreach (string slovo in strings_)
        {
            bool flag = true;
            foreach (char symbol in slovo)
            {
                if (Char.IsLower(symbol)) flag = false;
            }
            if (flag) ++count;
        }
        Console.WriteLine(count);
    }

}
