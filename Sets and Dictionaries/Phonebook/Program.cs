using System;
using System.Collections.Generic;

namespace Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "search")
            {
                string[] data = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                string key = data[0];
                string value = data[1];
                phonebook[key] = value;
            }

            while ((input = Console.ReadLine()) != "stop")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
            }
        }
    }
}