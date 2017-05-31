using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class TextTransformer
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();
        string input = Console.ReadLine();
        while (input != "burp")
        {
            text.Append(input);
            input = Console.ReadLine();
        }

        string result = Regex.Replace(text.ToString(), @"\s{2,}", " ");

        string pattern = @"([$&%'])([^$&%']+)\1";
        Regex regSeparate = new Regex(pattern);
        MatchCollection matches = regSeparate.Matches(result);

        var outputText = new List<char>();
        bool isEven = true;
        int argumnet = 0;
        foreach (Match match in matches)
        {
            isEven = true;
            string output = match.Groups[2].Value;
            string specSymbol = match.Groups[1].Value;

            char[] arr = output.ToCharArray();
            switch (specSymbol)
            {
                case "$":
                    argumnet = 1;
                    break;
                case "%":
                    argumnet = 2;
                    break;
                case "&":
                    argumnet = 3;
                    break;
                case "'":
                    argumnet = 4;
                    break;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (isEven)
                {
                    int symb = arr[i] + argumnet;
                    outputText.Add(((char)(symb)));

                    isEven = false;
                }
                else
                {
                    int symb = arr[i] - argumnet;
                    outputText.Add(((char)(symb)));
                    isEven = true;
                }
            }
            outputText.Add(' ');
        }
        Console.WriteLine(string.Join("", outputText));
    }
}