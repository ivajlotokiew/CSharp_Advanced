using System;
using System.Collections.Generic;

namespace Problem_6.A_miner_task
{
    class MinerTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> store = new Dictionary<string, int>();
            string input = String.Empty;
            int counter = 0;
            string name = string.Empty;
            int value = 0;

            while ((input = Console.ReadLine()) != "stop")
            {
                if (counter % 2 == 0)
                {
                    name = input;

                    if (!store.ContainsKey(name))
                    {
                        store[name] = 0;
                    }
                }
                else
                {
                    value = int.Parse(input);
                    store[name] += value;
                }

                counter++;
            }

            foreach (var i in store)
            {
                Console.WriteLine($"{i.Key} -> {i.Value}");
            }
        }
    }
}