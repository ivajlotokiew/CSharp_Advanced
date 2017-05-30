using System;
using System.Text.RegularExpressions;

namespace Problem_5.Extract_Emails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:^|\s+)(?<mail>[A-Za-z0-9]{1}[^@\s]+@[^\.]*.[^\s]+[^\.-_\s]+)";
            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups["mail"]);
            }
        }
    }
}