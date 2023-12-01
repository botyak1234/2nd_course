using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class str
    {
        private
        string line;
        str(string line)
        {
            this.line = line;
        }
        public
        int count_digit()
        {
            int c = 0;
            foreach (char s in this.line)
            {
                if (Char.IsDigit(s)) c++;
            }
            return c;
        }

        void print_single()
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char s in this.line)
            {
                if (charCount.ContainsKey(s))
                {
                    charCount[s]++;
                }
                else
                {
                    charCount[s] = 1;
                }
            }

            foreach (char s in this.line)
            {
                if (charCount[s] == 1)
                {
                    Console.WriteLine(s);
                }
            }
        }


        void print_max_copy()
        {
            List<List<char>> row_array = new List<List<char>>();
            List<char> symb_row = new List<char>();
            int c = 0;
            int max_c = -1;
            int index = 0;
            foreach (char symb in this.line)
            {
                if (symb_row.Contains(symb))
                {
                    symb_row.Add(symb);
                    c++;
                }
                else
                {
                    if (c > max_c)
                    {
                        row_array.Add(symb_row);
                        symb_row.Clear();
                        symb_row.Add(symb);
                        max_c = c;
                        c = 0;
                    }
                }
            }
            foreach (char symb_in_list in symb_row)
            {
                Console.WriteLine(symb_in_list);
            }
        }


        int TotalCharacters
        {
            get
            {
                int c = 0;
                foreach (char symb in this.line) c++;
                return c;
            }
        }

    }
}
