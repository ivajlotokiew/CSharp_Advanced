using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringMatrixRotation
{
    class Program
    {
        static void Main()
        {
            List<string> matrix = new List<string>();
            string value = Console.ReadLine();
            int val = 0;
            string pattern = @"\d+";
            MatchCollection mateches = Regex.Matches(value, pattern);
            foreach (Match item in mateches)
            {
                val = Int32.Parse(item.Value);
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                matrix.Add(command);
                command = Console.ReadLine();
            }

            var result = matrix.Max(p => p.Length);
            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i] = matrix[i].PadRight(result, ' ');
            }
            switch (val % 360)
            {
                case 0:
                    for (int row = 0; row < matrix.Count; row++)
                    {
                        for (int col = 0; col < result; col++)
                        {
                            Console.Write(matrix[row][col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 90:
                    for (int col = 0; col < result; col++)
                    {
                        for (int row = matrix.Count - 1; row >= 0; row--)
                        {
                            Console.Write(matrix[row][col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 180:
                    for (int row = matrix.Count - 1; row >= 0; row--)
                    {
                        for (int col = result - 1; col >= 0; col--)
                        {
                            Console.Write(matrix[row][col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 270:
                    for (int col = result - 1; col >= 0; col--)
                    {
                        for (int row = 0; row < matrix.Count; row++)
                        {
                            Console.Write(matrix[row][col]);
                        }
                        Console.WriteLine();
                    }

                    break;
            }

        }
    }
}