using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks
{
    public class Stack
    {
        public static void Main()
        {
            var numbers = new Stack<int>();
            string input = Console.ReadLine();

            int[] nums = input.Trim().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                numbers.Push(nums[i]);
            }

            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }
    }
}