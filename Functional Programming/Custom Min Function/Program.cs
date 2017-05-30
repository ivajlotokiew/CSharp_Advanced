using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3.Custom_Min_Function
{
    class CustMinFunc
    {
        static void Main()
        {
            int[] insert = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            HashSet<int> set = new HashSet<int>();
            foreach (var i in insert)
            {
                set.Add(i);
            }

            Func<HashSet<int>, int> func = ints =>
            {
                int minEl = int.MaxValue;
                foreach (var i in ints)
                {
                    if (i < minEl)
                    {
                        minEl = i;
                    }
                }

                return minEl;
            };

            Console.WriteLine(func(set));
        }
    }
}