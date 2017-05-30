using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem_2.Sets_of_Elements
{
    class SetOfElements
    {
        static void Main(string[] args)
        {
            int[] numberSetElements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < numberSetElements[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int j = 0; j < numberSetElements[1]; j++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            var result = firstSet.Intersect(secondSet);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}