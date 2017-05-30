namespace _02.Students_by_First_and_Last_Name
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
                .Where(st => st[0].CompareTo(st[1]) == -1)
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));
        }
    }
}