namespace _09.Students_Enrolled_in_2014_or_2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> students = new List<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                students.Add(input);
                input = Console.ReadLine();
            }

            students.Select(st => st.Split())
                .Where(st => st[0].Substring(4, 2) == "14" || st[0].Substring(4, 2) == "15")
                .ToList()
                .ForEach(st => Console.WriteLine(string.Join(" ", st.Skip(1))));
        }
    }
}