using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Queues
{
    class Program
    {
        static void Main()
        {
            string[] data = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string withoutSpaces = string.Join("", data);
            Stack<char> parenthesesOpen = new Stack<char>();
            Queue<char> parenthesesClose = new Queue<char>();

            string[] firstPart = withoutSpaces.Split(new char[] { ']', ')', '}' });
            string[] secondPart = withoutSpaces.Split(new char[] { '[', '(', '{' });

            for (int i = 0; i < firstPart[0].Length; i++)
            {
                parenthesesOpen.Push(firstPart[0][i]);
                parenthesesClose.Enqueue(secondPart[secondPart.Length - 1][i]);
            }

            bool isOk = true;

            while (parenthesesOpen.Count != 0)
            {
                char sign1 = parenthesesOpen.Pop();
                char sign2 = parenthesesClose.Dequeue();

                if (sign1 == '(' && sign2 == ')'
                    || sign1 == '[' && sign2 == ']'
                    || sign1 == '{' && sign2 == '}')
                {
                    isOk = true;
                }
                else
                {
                    isOk = false;
                    break;
                }
            }

            if (isOk)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}