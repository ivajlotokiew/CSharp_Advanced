using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    private static void Main()
    {
        int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int row = matrixSize[0];
        int col = matrixSize[1];
        string word = Console.ReadLine();
        char[,] arr = new char[row, col];
        int rowIndex = 1;
        int indexBegin = 0;
        for (int i = row - 1; i >= 0; i--)
        {
            if (rowIndex % 2 != 0)
            {
                for (int j = col - 1; j >= 0; j--)
                {
                    if (indexBegin >= word.Length)
                    {
                        indexBegin = 0;
                    }
                    arr[i, j] = word[indexBegin];
                    indexBegin++;
                }
            }

            else
            {
                for (int j = 0; j < col; j++)
                {
                    if (indexBegin >= word.Length)
                    {
                        indexBegin = 0;
                    }
                    arr[i, j] = word[indexBegin];
                    indexBegin++;
                }
            }
            rowIndex++;
        }

        //for (int rowOne = 0; rowOne < arr.GetLength(0); rowOne++)
        //{
        //    for (int colOne = 0; colOne < arr.GetLength(1); colOne++)
        //    {
        //        Console.Write("{0}", arr[rowOne, colOne]);
        //    }

        //    Console.WriteLine();
        //}

        int[] shotCoord = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int imapctRow = shotCoord[0];
        int impactCol = shotCoord[1];
        int radius = shotCoord[2];
        ShootMatrix(arr, imapctRow, impactCol, radius);
        CheckIfCharsFallDown(arr, row, col);

        for (int rowOne = 0; rowOne < arr.GetLength(0); rowOne++)
        {
            for (int colOne = 0; colOne < arr.GetLength(1); colOne++)
            {
                Console.Write("{0}", arr[rowOne, colOne]);
            }

            Console.WriteLine();
        }
    }

    private static void ShootMatrix(char[,] arr, int impactRow, int impactCol, int radius)
    {
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                //(x - center_x)^2 + (y - center_y)^2 < radius^2
                if ((col - impactCol) * (col - impactCol) + (row - impactRow) * (row - impactRow) <= radius * radius)
                {
                    arr[row, col] = ' ';
                }
            }
        }

    }

    private static void CheckIfCharsFallDown(char[,] arr, int row, int col)
    {
        bool isFall = true;
        do
        {
            isFall = true;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((arr[i, j] != ' ') && (arr[i + 1, j] == ' '))
                    {
                        isFall = false;
                        char change = arr[i, j];
                        arr[i, j] = arr[i + 1, j];
                        arr[i + 1, j] = change;
                    }
                }
            }
        } while (!isFall);

    }
}