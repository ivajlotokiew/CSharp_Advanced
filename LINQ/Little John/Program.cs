namespace _12.Little_John
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        private const int RowCount = 4;
        private static int count1;
        private static int count2;
        private static int count3;

        public static void Main()
        {
            string pattern1 = @"(>>>----->>)";
            string pattern2 = @"(>>----->)";
            string pattern3 = @"(>----->)";

            for (int i = 0; i < RowCount; i++)
            {
                string input = Console.ReadLine();
                Regex regex1 = new Regex(pattern1);
                MatchCollection matches1 = regex1.Matches(input);
                count1 += matches1.Count;
                input = Regex.Replace(input, pattern1, " ");

                Regex regex2 = new Regex(pattern2);
                MatchCollection matches2 = regex2.Matches(input);
                count2 += matches2.Count;
                input = Regex.Replace(input, pattern2, " ");

                Regex regex3 = new Regex(pattern3);
                MatchCollection matches3 = regex3.Matches(input);
                count3 += matches3.Count;
                input = Regex.Replace(input, pattern3, " ");
            }

            int concat = int.Parse(count3.ToString() + count2 + count1);
            var result = Convert.ToInt32(Convert.ToString(concat, 2) +
                                         new string(Convert.ToString(concat, 2)
                                         .ToCharArray().Reverse().ToArray()), 2).ToString();

            Console.WriteLine(result);
        }
    }
}