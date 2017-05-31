using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_15___The_Numbers
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(?<nums>[0-9]+)");

            MatchCollection matches = regex.Matches(input);

            StringBuilder hexValue = new StringBuilder();
            foreach (Match match in matches)
            {
                int intValue = int.Parse(match.Groups["nums"].Value);
                hexValue.Append($"0x{intValue.ToString("X").PadLeft(4, '0')}-");
            }

            Console.WriteLine(hexValue.Remove(hexValue.Length - 1, 1));
        }
    }
}