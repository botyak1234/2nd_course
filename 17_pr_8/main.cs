using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp2
{
    class Programm
    {





        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("C:\\Users\\contest\\source\\repos\\ConsoleApp2\\ConsoleApp2\\input17.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter("C:\\Users\\contest\\source\\repos\\ConsoleApp2\\ConsoleApp2\\output17.txt"))
                {
                    string s = fileIn.ReadLine();
                    str line = new str(s);
                    str line2 = new str(s);
                    line.Show(fileOut);
                    line.print_single(fileOut);
                    line.print_max_copy(fileOut);
                    fileOut.WriteLine(line.TotalCharacters);
                    fileOut.WriteLine(line[3]);
                    fileOut.WriteLine(!line);
                    if (line)
                    {
                        fileOut.WriteLine(1);
                    }
                    else
                    {
                        fileOut.WriteLine(-1);
                    }
                    fileOut.WriteLine(line & line2);
                    string stoka = line;
                    str line3 = s;
                }
            }
        }
    }
}
