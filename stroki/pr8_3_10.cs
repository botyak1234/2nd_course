using System;
using System.ComponentModel.Design;

class chisla
{
   


    static void Main()
    {
        int count = 0;
        string s = Console.ReadLine();
        foreach(char i in s)
        {
            if (Char.IsUpper(i)) count++;
        }
        Console.WriteLine(count);
    }

}
