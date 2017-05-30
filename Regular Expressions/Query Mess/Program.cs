using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_9.Query_Mess
{
    class QueryMess
    {
        static void Main()
        {

            string text = Console.ReadLine()
                .Replace("%20", " ").Replace("+", " ");

            while (text != "END")
            {
                text = Regex.Replace(text, @"\s+", " ");
                int index = text.IndexOf("?", 0);

                if (text.Contains("?"))
                {
                    text = text.Remove(0, index + 1);
                }

                string[] pairs = text.Split('&');

                var bufferPairs = new Dictionary<string, List<string>>();

                for (int i = 0; i < pairs.Length; i++)
                {
                    string[] pair = pairs[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string key = pair[0].Trim();
                    string value = pair[1].Trim();

                    if (!bufferPairs.ContainsKey(key))
                    {
                        bufferPairs.Add(key, new List<string>());
                    }

                    bufferPairs[key].Add(value);
                }

                StringBuilder output = new StringBuilder();
                foreach (var pair in bufferPairs)
                {
                    output.Append(pair.Key + "=[");
                    foreach (var value in pair.Value)
                    {
                        output.Append($"{value}, ");
                    }

                    Console.Write(output.Remove(output.Length - 2, 2) + "]");
                    output.Clear();
                }

                Console.WriteLine();

                if ((text = Console.ReadLine()) == "END")
                {
                    break;
                }

                text = text.Replace("%20", " ").Replace("+", " ");
            }
        }
    }
}