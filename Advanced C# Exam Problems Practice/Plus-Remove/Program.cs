using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static void Main()
    {
        List<char[]> matrix = new List<char[]>();
        List<char[]> tempField = new List<char[]>();
        string input = Console.ReadLine();
        int fill = 0;
        while (input != "END")
        {
            matrix.Add(input.ToCharArray());
            tempField.Add(input.ToCharArray());

            input = Console.ReadLine();
        }

        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (!(row - 1 < 0 || col - 1 < 0 || row + 1 >= matrix.Count || col + 1 >= matrix[row].Length))
                {
                    if (char.ToLower(matrix[row][col]) == char.ToLower(matrix[row][col - 1]) && char.ToLower(matrix[row][col]) == char.ToLower(matrix[row][col + 1]) && char.ToLower(matrix[row][col]) == char.ToLower(matrix[row + 1][col]) && char.ToLower(matrix[row][col]) == char.ToLower(matrix[row - 1][col]))
                    {
                        tempField[row][col] = '\0';
                        tempField[row - 1][col] = '\0';
                        tempField[row + 1][col] = '\0';
                        tempField[row][col + 1] = '\0';
                        tempField[row][col - 1] = '\0';
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        foreach (var item in tempField)
        {
            Console.WriteLine(string.Join("", item.Where(i => !i.Equals('\0'))));
        }
    }
}