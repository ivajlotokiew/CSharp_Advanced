using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5.Applied_Arithmetics
{
    public class Program
    {
        public static void Main()
        {
            List<int> list = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        list = ArithmeticOperations(list, x => x + 1);
                        break;
                    case "multiply":
                        list = ArithmeticOperations(list, x => x * 2);
                        break;
                    case "subtract":
                        list = ArithmeticOperations(list, x => x - 1);
                        break;
                    case "print":
                        foreach (int i in list)
                        {
                            PrintMethod(Console.Write, i);
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine();
        }

        public static List<int> ArithmeticOperations(List<int> list, Func<int, int> func)
        {
            var collection = new List<int>();

            foreach (var i in list)
            {
                collection.Add(func(i));
            }

            return collection;
        }

        public static void PrintMethod(Action<string> action, int num)
        {
            action(num + " ");
        }
    }
}