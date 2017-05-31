using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        List<char[]> matrix = new List<char[]>();
        List<char[]> matrixCopy = new List<char[]>();

        string command = Console.ReadLine();

        while (command != "END")
        {
            matrix.Add(command.ToCharArray());
            matrixCopy.Add(command.ToCharArray());
            command = Console.ReadLine();
        }

        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                int negRow = row - 1;
                int negCol = col - 1;
                int posRow = row + 1;
                int posCol = col + 1;
                char target = matrix[row][col];


                if (!(negRow < 0 || negCol < 0 || posRow >= matrix.Count || posCol >= matrix[posRow].Length || posCol >= matrix[negRow].Length))
                {
                    if (char.ToLower(target) == char.ToLower(matrix[negRow][negCol]) && char.ToLower(target) == char.ToLower(matrix[negRow][posCol]) && char.ToLower(target) == char.ToLower(matrix[posRow][negCol]) && char.ToLower(target) == char.ToLower(matrix[posRow][posCol]))
                    {
                        matrixCopy[row][col] = '\0';
                        matrixCopy[negRow][negCol] = '\0';
                        matrixCopy[negRow][posCol] = '\0';
                        matrixCopy[posRow][posCol] = '\0';
                        matrixCopy[posRow][negCol] = '\0';
                    }
                }
                else
                {
                    continue;

                }
            }
        }

        foreach (var item in matrixCopy)
        {
            Console.WriteLine(string.Join("", item.Where(i => !i.Equals('\0'))));
        }

    }
}