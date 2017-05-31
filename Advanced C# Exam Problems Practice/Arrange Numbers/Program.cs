using System;
using System.Collections.Generic;
using System.Text;

namespace Arrange_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new Dictionary<int, string>()
            {
                {0, "zero"}, {1, "one"}, {2, "two"},
                { 3, "three"}, {4, "four"}, { 5, "five"},
                { 6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}
            };

            var buffer = new SortedDictionary<string, List<string>>();
            string parts = String.Empty;

            string[] sequneceNumbers = Console.ReadLine().Split(new char[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sequneceNumbers.Length; i++)
            {
                for (int j = 0; j < sequneceNumbers[i].Length; j++)
                {
                    string digit = sequneceNumbers[i].ToCharArray()[j].ToString();
                    foreach (int key in nums.Keys)
                    {
                        if (int.Parse(digit) == key)
                        {
                            parts += nums[key];
                            break;
                        }
                    }
                }

                if (!buffer.ContainsKey(parts))
                {
                    buffer.Add(parts, new List<string>());
                }

                buffer[parts].Add(sequneceNumbers[i]);
                parts = String.Empty;
            }

            StringBuilder output = new StringBuilder();

            foreach (var value in buffer.Values)
            {
                output.Append(string.Join(", ", value) + ", ");
            }

            Console.WriteLine(output.Remove(output.Length - 2, 1));
        }
    }
}