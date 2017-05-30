using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Queues
{
    class TruckTour
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            List<int> fuel = new List<int>();
            Queue<int> buffer = new Queue<int>();


            for (int i = 0; i < N; i++)
            {
                int[] data =
                    Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                int pompFuel = data[0];
                int km = data[1];

                fuel.Add(pompFuel - km);
            }

            int index = 0;
            int checker = 0;

            while (index < N)
            {
                for (int i = 0; i <= fuel.Count; i++)
                {
                    int gaz = fuel[i];
                    checker += gaz;
                    buffer.Enqueue(i);

                    if (checker < 0)
                    {
                        checker = 0;
                        index = 0;
                        buffer.Clear();
                        continue;
                    }

                    index++;

                    if (index == N)
                    {
                        break;
                    }

                    if (i + 1 == fuel.Count)
                    {
                        i = -1;
                    }
                }
            }

            Console.WriteLine(buffer.Dequeue());
        }
    }
}