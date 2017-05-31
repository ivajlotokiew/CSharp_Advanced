using System;
using System.Linq;

class BunkerBuster
{
    static void Main()
    {
        int[] matrixDimension = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int row = matrixDimension[0];
        int col = matrixDimension[1];
        int[,] matrix = new int[row, col];
        int negative = 0;
        int deadCells = 0;
        for (int i = 0; i < row; i++)
        {
            string[] cellInfo = Console.ReadLine().Split(' ');
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = int.Parse(cellInfo[j]);
            }
        }

        string command = Console.ReadLine();
        while (command != "cease fire!")
        {
            string[] commands = command.Split(' ');
            int rowTarget = int.Parse(commands[0]);
            int colTarget = int.Parse(commands[1]);
            int pointDemage = char.Parse(commands[2]);
            int rowBottom = rowTarget - 1;
            int colBottom = colTarget - 1;
            int rowEdge = rowTarget + 1;
            int colEdge = colTarget + 1;

            for (int i = rowBottom; i <= rowEdge; i++)
            {
                for (int j = colBottom; j <= colEdge; j++)
                {
                    if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1) || matrix[i, j] <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (i == rowTarget && j == colTarget)
                        {
                            matrix[i, j] = matrix[i, j] - pointDemage;
                        }
                        else
                        {
                            matrix[i, j] = matrix[i, j] - (int)Math.Ceiling((pointDemage / 2.0));
                        }
                    }

                    if (matrix[i, j] <= 0)
                    {
                        negative++;
                    }
                }
            }

            deadCells += negative;
            negative = 0;
            command = Console.ReadLine();
        }

        double result = (double)deadCells / (matrix.GetLength(0) * matrix.GetLength(1));
        Console.WriteLine("Destroyed bunkers: {0}", deadCells);
        Console.WriteLine("Damage done: {0:F1} %", Math.Round(100 * result, 2));

    }
}