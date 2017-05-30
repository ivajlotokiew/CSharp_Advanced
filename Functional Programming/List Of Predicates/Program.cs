using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9.List_of_Predicates
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> set = new HashSet<int>
                (Console.ReadLine().Split().Select(int.Parse).ToList());

            for (int i = 1; i <= n; i++)
            {
                int result = DivisionMethod(x => i % x == 0, set, i);
                if (result != -1)
                {
                    Console.Write(result + " ");
                }
            }

            Console.WriteLine();
        }

        public static int DivisionMethod(Predicate<int> predicate, HashSet<int> set, int divise)
        {
            int result = -1;
            bool isReult = true;

            foreach (var i in set)
            {
                if (!predicate(i))
                {
                    isReult = false;
                    break;
                }
            }

            if (isReult)
            {
                result = divise;
            }

            return result;
        }
    }
}