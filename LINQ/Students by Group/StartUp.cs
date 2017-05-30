namespace _01.Students_by_Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<string> stringList = new List<string>();

            while (input != "END")
            {
                stringList.Add(input);

                input = Console.ReadLine();
            }

            stringList
                .Select(st => st.Split())
                .Where(st => int.Parse(st[2]) == 2)
                .OrderBy(st => st[0])
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));
        }
    }
}