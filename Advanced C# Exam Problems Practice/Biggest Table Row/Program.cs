using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Problem_17___Biggest_Table_Row
{
    class TableRow
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string input = String.Empty;

            Regex regex = new Regex(@">\s*(-*[0-9]+\.*[0-9]*)<");
            double maxSum = double.MinValue;
            double curSum = 0;
            string output = String.Empty;
            bool isResult = false;

            while ((input = Console.ReadLine()) != "</table>")
            {
                MatchCollection matches = regex.Matches(input);

                if (matches.Count > 0)
                {
                    isResult = true;
                    StringBuilder outputBuilder = new StringBuilder();

                    foreach (Match match in matches)
                    {
                        curSum += double.Parse(match.Groups[1].Value);
                        outputBuilder.Append($"{match.Groups[1].Value}" + " + ");
                    }

                    if (maxSum < curSum)
                    {
                        maxSum = curSum;
                        output = outputBuilder.ToString();
                    }

                    curSum = 0;
                }
            }

            if (isResult)
            {
                Console.WriteLine($"{maxSum} = {output.Remove(output.Length - 3, 3)}");
            }
            else
            {
                Console.WriteLine("no data");
            }
        }
    }
}