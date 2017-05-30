namespace _03.Students_by_Age
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

            students
              .Select(st => st.Split())
              .Where(st => int.Parse(st[2]) >= 18 && int.Parse(st[2]) <= 24)
              .ToList()
              .ForEach(st => Console.WriteLine($"{st[0]} {st[1]} {st[2]}"));
        }
    }
}