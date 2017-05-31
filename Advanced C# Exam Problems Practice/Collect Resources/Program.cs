using System;
using System.Linq;

namespace Collect_Resources
{
    class Program
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split();
            int[] intArr = new int[elements.Length];

            for (var i = 0; i < elements.Length; i++)
            {
                int value = 1;
                string[] parts = elements[i].Split('_');
                string name = parts[0];
                if (parts.Length > 1)
                {
                    value = int.Parse(parts[1]);
                }

                if (name == "stone" || name == "gold" || name == "wood" || name == "food")
                {
                    intArr[i] = value;
                }
                else
                {
                    intArr[i] = -1;
                }
            }

            int paths = int.Parse(Console.ReadLine());
            int[] copyArr = new int[elements.Length];
            Array.Copy(intArr, copyArr, elements.Length);
            int maxSum = 0;

            for (int i = 0; i < paths; i++)
            {
                int sum = 0;
                int[] args = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int start = args[0];
                int step = args[1];
                int index = start;

                while (intArr[index] != 0)
                {
                    if (intArr[index] != -1)
                    {
                        sum += intArr[index];
                        intArr[index] = 0;
                    }

                    index = (index + step) % elements.Length;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                Array.Copy(copyArr, intArr, elements.Length);
            }

            Console.WriteLine(maxSum);
        }
    }
}