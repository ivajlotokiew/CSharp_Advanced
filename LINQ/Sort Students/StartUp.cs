namespace _04.Sort_Students
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
                .OrderBy(st => st[1])
                .ThenByDescending(st => st[0])
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));
        }
    }
}