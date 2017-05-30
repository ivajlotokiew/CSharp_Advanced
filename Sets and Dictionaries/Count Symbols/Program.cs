using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem_4.Count_Symbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            var dictionary = new SortedDictionary<char, int>();
            char[] text = Console.ReadLine().ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dictionary.ContainsKey(text[i]))
                {
                    dictionary.Add(text[i], 0);
                }

                dictionary[text[i]]++;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}