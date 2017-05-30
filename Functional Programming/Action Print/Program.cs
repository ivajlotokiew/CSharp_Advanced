using System;
using System.Collections.Generic;

namespace Problem_1.Action_Print_SecondWay
{
    public class ActionPrint
    {
        public static void Main()
        {
            string[] data = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in data)
            {
                PrintMethod(Console.WriteLine, s);
            }
        }

        public static void PrintMethod(Action<string> action, string name)
        {
            action(name);
        }
    }
}