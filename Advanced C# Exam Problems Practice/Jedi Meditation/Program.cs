namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class JMeditation
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<List<string>> jedisOutput = new List<List<string>>();

            for (int i = 0; i < 4; i++)
            {
                jedisOutput.Add(new List<string>());
            }

            StringBuilder jedisBuilder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                jedisBuilder.Append(Console.ReadLine() + " ");
            }

            List<string> listJedi =
                jedisBuilder.ToString()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            bool isYoda = false;

            for (int i = 0; i < listJedi.Count; i++)
            {
                char jediType = listJedi[i][0];

                switch (jediType)
                {
                    case 'm':
                        jedisOutput[1].Add(listJedi[i]);
                        break;
                    case 'k':
                        jedisOutput[2].Add(listJedi[i]);
                        break;
                    case 'p':
                        jedisOutput[3].Add(listJedi[i]);
                        break;
                    case 'y':
                        isYoda = true;
                        break;
                    default:
                        jedisOutput[0].Add(listJedi[i]);
                        break;
                }
            }

            if (isYoda)
            {
                var temp = jedisOutput[0];
                jedisOutput.RemoveAt(0);
                jedisOutput.Insert(2, temp);
            }

            Console.WriteLine(string.Join(" ", jedisOutput.SelectMany(list => list)));
        }
    }
}