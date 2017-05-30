using System.Text;

namespace _13.Office_Stuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var officeStufs = new SortedDictionary<string, HashSet<Office>>();

            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                var data = input.Substring(1, input.Length - 2).Trim().Split('-');

                var name = data[0].Trim();
                var amount = int.Parse(data[1].Trim());
                var product = data[2].Trim();

                if (!officeStufs.ContainsKey(name))
                {
                    officeStufs.Add(name, new HashSet<Office>());
                }

                if (officeStufs[name].Any(x => x.Product == product))
                {
                    officeStufs[name].Single(x => x.Product == product).Amount += amount;
                    continue;
                }

                officeStufs[name].Add(new Office(name, amount, product));
            }

            foreach (var value in officeStufs)
            {
                var output = new StringBuilder();
                output.Append($"{value.Key}: ");
                foreach (var val in value.Value)
                {
                    output.Append($"{val.Product}-{val.Amount}, ");
                }

                Console.WriteLine(output.Remove(output.Length - 2, 1));
            }
        }
    }
}
