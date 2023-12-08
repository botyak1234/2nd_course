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
                    else
                    {
                        c = 0;
                    }
                }
            }
            List<char> lastItem = row_array.Last();
            foreach(char element in lastItem) Console.WriteLine(element);
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

        public char this[int i]
        {
            get 
            {
                if (i < TotalCharacters)
                {
                    return line[i];
                }
                else
                {
                    Console.WriteLine("Недопустимый индекс");
                    return '!';
                }
            }
        }

        public static bool operator !(str myString)
        {
            if (myString.TotalCharacters != 0) return true;
            else return false;
        }

        public static bool IsPalindrome(string str)
        {
            string reversed = new string(str.Reverse().ToArray());
            return string.Equals(str, reversed, StringComparison.OrdinalIgnoreCase);
        }


        public static bool operator true(str myString)
        {
            return IsPalindrome(myString.line);
        }

        public static bool operator false(str myString)
        {
            return !IsPalindrome(myString.line);
        }

        public static bool operator &(str obj1, str obj2)
        {
            if (obj1.Field.Length != obj2.Field.Length)
                return false;

            for (int i = 0; i < obj1.Field.Length; i++)
            {
                if (char.ToLower(obj1.Field[i]) != char.ToLower(obj2.Field[i]))
                    return false;
            }

            return true;
        }

    }
}
