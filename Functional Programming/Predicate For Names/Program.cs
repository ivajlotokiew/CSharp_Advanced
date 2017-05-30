using System;

namespace Problem_7.Predicate_for_names
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] strings = Console.ReadLine().Split();

            foreach (var word in strings)
            {
                PrintWordsByLength(x => x.Length <= n, word);
            }

        }

        public static void PrintWordsByLength(Predicate<string> predicate, string word)
        {
            if (predicate(word))
            {
                Console.WriteLine(word);
            }
        }
    }
}