using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

class Programm
{
    //static void Main()
    //{
    //    List<string> numbers;
    //    string s;
    //    char[] chars = { ' ', '\n', '\t', '.', ',', '!', ':', '"', '\'', '\\', '/' };
    //    using (StreamReader fileIn = new StreamReader("C:\\Users\\Danil\\source\\repos\\ConsoleApp1\\ConsoleApp1\\input.txt"))
    //    {
    //        s = fileIn.ReadLine();
    //        numbers = new List<string>(s.Split(chars, StringSplitOptions.RemoveEmptyEntries));
    //    }
    //    var NewNumbers = from n in numbers
    //                     where n.Length == 3
    //                     select int.Parse(n) - 100;


    //    using (StreamWriter fileOut = new StreamWriter("C:\\Users\\Danil\\source\\repos\\ConsoleApp1\\ConsoleApp1\\output.txt"))
    //    {
    //        foreach (var x in NewNumbers)
    //        {
    //            fileOut.Write("{0} ", x);
    //        }
    //    }
    //}
    static void Main()
    {
        List<string> numbers;
        string s;
        char[] chars = { ' ', '\n', '\t', '.', ',', '!', ':', '"', '\'', '\\', '/' };
        using (StreamReader fileIn = new StreamReader("C:\\Users\\contest\\source\\repos\\ConsoleApp2\\ConsoleApp2\\input.txt"))
        {
            using (StreamWriter fileOut = new StreamWriter("C:\\Users\\contest\\source\\repos\\ConsoleApp2\\ConsoleApp2\\output.txt"))
            {
                while((s = fileIn.ReadLine()) != null)              
                {
                    numbers = new List<string>(s.Split(chars, StringSplitOptions.RemoveEmptyEntries));
                    var NewNumbers = numbers.Where(n => n.Length == 3).Select(n => int.Parse(n) - 100);
                    {
                        foreach (var x in NewNumbers)
                        {
                            fileOut.Write("{0} ", x);
                        }
                    }
                }
            }
        }
    }
}
