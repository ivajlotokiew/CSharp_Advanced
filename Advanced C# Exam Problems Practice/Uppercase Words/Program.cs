using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = @"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])";
            Regex regex = new Regex(sentence);
            string line = String.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                MatchCollection matches = regex.Matches(line);

                int offset = 0;
                foreach (Match match in matches)
                {
                    string reversed = Reverse(match.ToString());

                    if (reversed == match.ToString())
                    {
                        reversed = DoubleWord(reversed);
                    }

                    line = line.Remove(match.Index + offset, match.Value.Length);
                    line = line.Insert(match.Index + offset, reversed);
                    offset += reversed.Length - match.ToString().Length;
                }

                Console.WriteLine(SecurityElement.Escape(line));
            }
        }

        private static string DoubleWord(string reverse)
        {
            StringBuilder doubledWord = new StringBuilder();

            for (int i = 0; i < reverse.Length; i++)
            {
                doubledWord.Append(new string(reverse[i], 2));
            }

            return doubledWord.ToString();
        }

        private static string Reverse(string value)
        {
            StringBuilder reversedWord = new StringBuilder();

            for (int i = value.Length - 1; i >= 0; i--)
            {
                reversedWord.Append(value[i]);
            }

            return reversedWord.ToString();
        }
    }
}