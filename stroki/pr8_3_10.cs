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
        char[] chars = {' ','\n','\t','.', ',', '!',':','"', '\'','\\','/'};
        List<string>strings_ = new List<string>(s.Split(chars, StringSplitOptions.RemoveEmptyEntries));
        Console.WriteLine(strings_.Count());
        foreach (string slovo in strings_)
        {
            if (slovo == slovo.ToUpper()) count++;
        }
        Console.WriteLine(count);
    }

}
