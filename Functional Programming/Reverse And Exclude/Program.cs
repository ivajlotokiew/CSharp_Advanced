using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6.Reverse_and_exclude
{
    public class Program
    {
        public static void Main()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            int divider = int.Parse(Console.ReadLine());

            list = ReverseMethod(list, x => x);

            foreach (var i in list)
            {
                PrintDividerNubers(x => x % divider != 0, i);
            }

            Console.WriteLine();
        }

        public static List<int> ReverseMethod(List<int> list, Func<int, int> func)
        {
            var collection = new List<int>();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                collection.Add(list[i]);
            }

            return collection;
        }

        public static void PrintDividerNubers(Predicate<int> predicate, int num)
        {
            if (predicate(num))
            {
                Console.Write(num + " ");
            }
        }
    }
}