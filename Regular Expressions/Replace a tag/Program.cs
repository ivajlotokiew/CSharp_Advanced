using System;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"<a\s*href=\s*([^\>]*)>([^\<]*)</a>";
            string text = Console.ReadLine();

            var regex = new Regex(pattern);

            string replacement = "[URL href=$1]$2[/URL]";
            string result = Regex.Replace(text, pattern, replacement);
            Console.WriteLine(result);
        }
    }
}