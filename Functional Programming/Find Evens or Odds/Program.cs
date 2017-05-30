namespace Problem_4.Find_Evens_or_Odds_Second
{
    using System;
    using System.Linq;

    class FindOddOrEven
    {
        public static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int begin = range[0];
            int end = range[1];
            string oddOrEven = Console.ReadLine();

            for (int i = begin; i <= end; i++)
            {
                if (oddOrEven == "odd")
                {
                    PrintResult(x => x % 2 != 0, i);
                }
                else
                {
                    PrintResult(x => x % 2 == 0, i);
                }
            }
        }

        public static void PrintResult(Predicate<int> predicate, int num)
        {
            if (predicate(num))
            {
                Console.Write(num + " ");
            }
        }
    }
}