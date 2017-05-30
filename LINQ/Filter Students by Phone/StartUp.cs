namespace _06.Filter_Students_by_Phone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
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
                .Where(st => st[2].Substring(0, 2) == "02" || st[2].Substring(0, 5) == "+3592")
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));
        }
    }
}