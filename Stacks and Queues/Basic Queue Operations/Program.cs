using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03.Stacks
{
    class MaximumElement
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < N; i++)
            {

                string[] commands = Console.ReadLine().Split(' ');

                short command = short.Parse(commands[0]);

                switch (command)
                {
                    case 2:
                        numbers.Pop();
                        break;
                    case 3:
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine(0);
                        }
                        else
                        {
                            int maxEl = numbers.Max(x => x);
                            Console.WriteLine($"{maxEl}");
                        }

                        break;
                    case 1:
                        int pushedEl = int.Parse(commands[1]);
                        numbers.Push(pushedEl);
                        break;
                }
            }
        }
    }
}