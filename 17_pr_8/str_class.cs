using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class str
    {
        private
        string line;
        public str(string line)
        {
            this.line = line;
        }

        public str(str new_obj)
        {
            this.line = String.Copy(new_obj.line);
        }

        public str()
        {
            this.line = " ";
        }
        public void Show(StreamWriter fileout)
        {
            fileout.Write(line);
            fileout.WriteLine();
        }

        public int count_digit()
        {
            int c = 0;
            foreach (char s in this.line)
            {
                if (Char.IsDigit(s)) c++;
            }
            return c;
        }

        public void print_single(StreamWriter fileout)
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
                    fileout.Write("{0} ", s);
                }
            }
            fileout.WriteLine();
        }


        public void print_max_copy(StreamWriter fileout)
        {
            if (string.IsNullOrEmpty(line))
            {
                fileout.WriteLine(string.Empty);
            }
            char currentChar = line[0];
            char maxChar = line[0];
            int currentCount = 1;
            int maxCount = 1;
            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == currentChar)
                {
                    currentCount++;
                }
                else 
                {
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        maxChar = currentChar;
                    }
                    currentChar = line[i];
                    currentCount = 1;
                }
            }
            for (int i = 0; i < maxCount; i++)
            {
                fileout.Write(maxChar);
            }
            fileout.WriteLine();
        }


        public int TotalCharacters
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
                    throw new Exception("Неправильный индекс");
                }
            }
        }

        public static bool operator !(str myString)
        {
            if (myString.TotalCharacters != 0) return true;
            else return false;
        }

        public static bool IsPalindrome(string stroka)
        {
            char[] charArray = stroka.ToCharArray();
            Console.WriteLine(stroka);
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            Console.WriteLine(reversed);
            return string.Equals(stroka, reversed, StringComparison.OrdinalIgnoreCase);
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
            if (obj1.TotalCharacters != obj2.TotalCharacters)
                return false;

            for (int i = 0; i < obj1.TotalCharacters; i++)
            {
                if (char.ToLower(obj1[i]) != char.ToLower(obj2[i]))
                    return false;
            }

            return true;
        }

        public static implicit operator str(string s)
        {
            return new str(s);
        }

        public static implicit operator string(str s)

        {
            string temp = new string(s.line);
            return temp;
        }
    }
}
