namespace _10.Group_by_Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        public string Name { get; set; }

        public int Group { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            List<Person> personList = new List<Person>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                List<string> dataList = input.Split().ToList();

                string name = dataList[0] + " " + dataList[1];
                int group = int.Parse(dataList[2]);

                personList.Add(new Person()
                {
                    Name = name,
                    Group = group
                });

                input = Console.ReadLine();
            }

            var result = personList.GroupBy(st => st.Group).OrderBy(st => st.Key);

            StringBuilder output = new StringBuilder();
            foreach (var item in result)
            {
                output.Append($"{item.Key} - ");

                foreach (var person in item)
                {
                    output.Append(person.Name + ", ");
                }

                Console.WriteLine(output.Remove(output.Length - 2, 2));
                output.Clear();
            }
        }
    }
}