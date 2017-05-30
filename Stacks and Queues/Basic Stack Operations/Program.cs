using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Stacks
{
    class StackExercise
    {
        static void Main()
        {
            int[] commands =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            int amountPushedEl = commands[0];
            int amountPopedEl = commands[1];
            int checkedEl = commands[2];
            var numbers = new Stack<int>();

            int[] nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            for (int i = 0; i < amountPushedEl; i++)
            {
                numbers.Push(nums[i]);
            }

            for (int i = 0; i < amountPopedEl; i++)
            {
                numbers.Pop();
            }

            bool hasExist = numbers.Contains(checkedEl);

            int min = Int32.MaxValue;

            if (amountPushedEl == amountPopedEl)
            {
                Console.WriteLine("0");
            }
            else if (!hasExist)
            {
                while (numbers.Count != 0)
                {
                    int current = numbers.Pop();

                    if (min > current)
                    {
                        min = current;
                    }
                }

                Console.WriteLine($"{min}");
            }
            else
            {
                Console.WriteLine("true");
            }
        }
    }
}