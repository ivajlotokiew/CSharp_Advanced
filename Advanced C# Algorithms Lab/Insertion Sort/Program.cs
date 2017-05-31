using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Algorithms
{
    static void Main(string[] args)
    {
        int[] matrix = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


        int larger = 0;
        for (int j = 0; j < matrix.Length; j++)
        {
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i - 1] > matrix[i])
                {
                    larger = matrix[i - 1];
                    matrix[i - 1] = matrix[i];
                    matrix[i] = larger;
                }
            }
        }

        Console.WriteLine(string.Join(" ", matrix));

    }
}