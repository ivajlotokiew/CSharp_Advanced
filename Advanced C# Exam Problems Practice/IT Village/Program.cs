using System;
using System.Linq;

namespace Problem_21___IT_Village
{
    public class ItVillage
    {
        private static int coins = 50;

        public static void Main()
        {
            string[] input = Console.ReadLine().Trim()
                .Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

            int[] start = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int startRow = start[0] - 1;
            int startCol = start[1] - 1;

            string[,] boarder = new string[4, 4];
            int index = 0;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    boarder[row, col] = input[index];
                    index++;
                }
            }

            boarder[startRow, startCol] += "_";

            string fields = String.Empty;
            for (int col = 0; col < 4; col++)
            {
                fields += boarder[0, col];
            }
            for (int row = 1; row < 4; row++)
            {
                fields += boarder[row, 3];
            }
            for (int col = 2; col >= 0; col--)
            {
                fields += boarder[3, col];
            }
            for (int row = 2; row > 0; row--)
            {
                fields += boarder[row, 0];
            }

            int startIndex = fields.IndexOf("_") - 1;
            fields = fields.Remove(startIndex + 1, 1);

            int[] moves = Console.ReadLine()
           .Trim()
           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse).ToArray();
            int count = 0;
            int nextMove = startIndex + moves[count];

            int innsCount = 0;
            int inns = fields.Count(st => st == 'I');

            while (true)
            {
                coins += innsCount * 20;
                if (nextMove >= fields.Length)
                {
                    nextMove = nextMove % (fields.Length);
                }

                string condition = CurrentMove(fields, nextMove);

                if (condition == "Inn")
                {
                    if (coins >= 100)
                    {
                        fields = fields.Remove(nextMove, 1).Insert(nextMove, "$");
                        coins -= 100;
                        innsCount++;

                        if (innsCount == inns)
                        {
                            GameOver("I own all Inns", coins);
                            return;
                        }
                    }
                    else
                    {
                        coins -= 10;
                        if (coins < 0)
                        {
                            GameOver("No more coins", coins);
                            return;
                        }
                    }
                }
                else if (condition == "Storm")
                {
                    count += 2;
                    if (count + 1 >= moves.Length)
                    {
                        GameOver("No more moves", coins);
                        return;
                    }
                }
                else if (condition == "Win")
                {
                    GameOver("Nakov bonus", coins);
                    return;
                }

                count++;
                if (count >= moves.Length)
                {
                    GameOver("No more moves", coins);
                    return;
                }

                nextMove += moves[count];
            }
        }

        public static string CurrentMove(string fields, int index)
        {
            char command = fields[index];

            switch (command)
            {
                case 'P':
                    coins -= 5;
                    return null;
                case 'F':
                    coins += 20;
                    return null;
                case 'V':
                    coins *= 10;
                    return null;
                case 'N':
                    return "Win";
                case 'S':
                    return "Storm";
                case 'I':
                    return "Inn";
                case '$':
                    return "My Inn";
            }

            return null;
        }

        public static void GameOver(string message, int coins)
        {
            if (message == "No more coins")
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
            }
            else if (message == "No more moves")
            {
                Console.WriteLine($"<p>You lost! No more moves! You have {coins} coins!<p>");
            }
            else if (message == "Nakov bonus")
            {
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
            }
            else
            {
                Console.WriteLine($"<p>You won! You own the village now! You have {coins} coins!<p>");
            }
        }
    }
}