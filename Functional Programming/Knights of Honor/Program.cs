using System;

namespace Problem_2.Knights_of_Honor
{
    class KingsOfHonnor
    {
        static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                PrintMethod(Console.WriteLine, name);
            }
        }

        public static void PrintMethod(Action<string> collection, string name)
        {
            collection($"Sir {name}");
        }
    }
}