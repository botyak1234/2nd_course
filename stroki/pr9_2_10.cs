
using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;

class chisla
{



    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        using (StreamReader file_f = new StreamReader("C:\\Users\\Пользователь\\source\\repos\\help\\help\\f.txt", Encoding.GetEncoding(1251)))
        {
            using (StreamWriter file_h = new StreamWriter("C:\\Users\\Пользователь\\source\\repos\\help\\help\\h.txt"))
            {
                using (StreamWriter file_g = new StreamWriter("C:\\Users\\Пользователь\\source\\repos\\help\\help\\g.txt"))
                {
                    string sline;
                    while ((sline = file_f.ReadLine()) != null)
                    {
                        foreach (char symb in sline)
                        {
                            if (Char.IsPunctuation(symb)) file_g.Write("{0} ", symb);
                            else file_h.Write("{0}", symb);
                        }
                    }
                }
            }
        }
    }
}
