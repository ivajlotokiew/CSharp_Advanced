using System;
using System.Collections.Generic;

namespace Problem_3.Periodic_Table
{
    class PeriodicTable
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();
                foreach (var element in elements)
                {
                    set.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}