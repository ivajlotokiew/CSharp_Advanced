using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string patternNonDigit = @"\D+";
        StringBuilder concat = new StringBuilder();

        Regex rgxNoDigit = new Regex(patternNonDigit);
        MatchCollection matchNoDigit = rgxNoDigit.Matches(input);

        string patternDigit = @"\d+";
        Regex rgxDigit = new Regex(patternDigit);
        MatchCollection matchDigit = rgxDigit.Matches(input);

        for (int i = 0; i < matchDigit.Count; i++)
        {
            for (int j = 0; j < int.Parse(matchDigit[i].Value); j++)
            {
                concat.Append(matchNoDigit[i].Value);
            }
        }

        Console.WriteLine("Unique symbols used: {0}", concat.ToString().ToUpper().ToList().Distinct().Count());
        Console.WriteLine(concat.ToString().ToUpper());
    }
}