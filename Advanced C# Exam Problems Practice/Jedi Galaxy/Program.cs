using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SecondNature
{
    public class StartUp
    {
        private static int rows;
        private static int cols;
        private static int[,] matrix = new int[rows, cols];
        private static long totalSum = 0;

        public static void Main()
        {
            string[] line = Console.ReadLine().Split();
            rows = int.Parse(line[0]);
            cols = int.Parse(line[1]);
            int count = 0;

            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = count;
                    count++;
                }
            }

            while (true)
            {
                string data = Console.ReadLine();

                if (data == "Let the Force be with you")
                {
                    break;
                }

                int rowIvo = int.Parse(data.Split()[0]);
                int colIvo = int.Parse(data.Split()[1]);


                data = Console.ReadLine();
                int rowEnemy = int.Parse(data.Split()[0]);
                int colEnemy = int.Parse(data.Split()[1]);

                while (colEnemy >= 0 || rowEnemy >= 0)
                {
                    if (IsInTheMatrix(rowEnemy, colEnemy))
                    {
                        matrix[rowEnemy, colEnemy] = 0;
                    }

                    rowEnemy--;
                    colEnemy--;
                }

                while (rowIvo >= 0 && colIvo < cols)
                {
                    if (IsInTheMatrix(rowIvo, colIvo))
                    {
                        totalSum += matrix[rowIvo, colIvo];
                    }

                    rowIvo--;
                    colIvo++;
                }
            }

            Console.WriteLine(totalSum);
        }

        private static bool IsInTheMatrix(int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < rows &&
                currentCol >= 0 && currentCol < cols)
            {
                return true;
            }

            return false;
        }
    }
}