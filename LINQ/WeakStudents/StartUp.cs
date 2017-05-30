namespace _08.WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> students = new List<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                students.Add(input);
                input = Console.ReadLine();
            }

            students
                .Select(st => st.Split())
                .Where(st => st.Count(x => x.Contains("3") || x.Contains("2")) > 1)
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));

        }
    }
}