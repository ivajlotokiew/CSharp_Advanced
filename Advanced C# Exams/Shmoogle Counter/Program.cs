using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var dataBuffer = new List<string>();
        string pattern = @"int\b\s+([A-Za-z]+)|double\b\s+([A-Za-z]+)";
        var sortDoubleData = new List<string>();
        var sortIntData = new List<string>();
        Regex reg = new Regex(pattern);
        string inputDataBuffer = Console.ReadLine();
        bool isResult = false;

        while (inputDataBuffer != "//END_OF_CODE")
        {
            MatchCollection matches = reg.Matches(inputDataBuffer);
            foreach (Match item in matches)
            {
                if (!(item.Groups[2].ToString() == ""))
                {
                    sortDoubleData.Add(item.Groups[2].ToString());
                }
                if (!(item.Groups[1].ToString() == ""))
                {
                    sortIntData.Add(item.Groups[1].ToString());
                }
            }
            inputDataBuffer = Console.ReadLine();
        }
        sortDoubleData.Sort();
        sortIntData.Sort();

        if (sortDoubleData.Count != 0)
        {
            Console.WriteLine("Doubles: {0}", string.Join(", ", sortDoubleData));
        }
        else
        {
            Console.WriteLine("Doubles: None");
        }

        if (sortIntData.Count != 0)
        {
            Console.WriteLine("Ints: {0}", string.Join(", ", sortIntData));
        }
        else
        {
            Console.WriteLine("Ints: None");
        }
    }
}