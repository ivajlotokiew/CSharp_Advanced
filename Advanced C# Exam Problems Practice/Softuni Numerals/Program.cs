using System;

namespace Softuni_Numerals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' && input[i + 1] == 'a')
                {
                    result += 0;
                    i = i + 1;
                }
                else if (input[i] == 'a' && input[i + 1] != 'a')
                {
                    result += 1;
                    i = i + 2;
                }
                else if (input[i] == 'b')
                {
                    result += 2;
                    i = i + 2;
                }
                else if (input[i] == 'c' && input[i + 1] == 'c')
                {
                    result += 3;
                    i = i + 1;
                }
                else if (input[i] == 'c' && input[i + 1] != 'c')
                {
                    result += 4;
                    i = i + 2;
                }
            }

            Console.WriteLine(From5To10(result));
        }

        private static double From5To10(string num)
        {
            double result = 0;
            int index = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                result += int.Parse(num[i].ToString()) * Math.Pow(5, index);
                index++;
            }

            return result;
        }
    }
}