using System;
using System.Linq;

namespace Problem_16___Parachute
{
    public class Parachute
    {
        public static void Main()
        {
            string row = Console.ReadLine();

            int col = 0;
            int indexParachut = row.IndexOf('o');
            while (indexParachut < 0)
            {
                row = Console.ReadLine();
                indexParachut = row.IndexOf('o');
                col++;
            }

            while ((row = Console.ReadLine()) != "END")
            {
                int windMove = FindWindMove(row);
                int parachutPossition = indexParachut + windMove;
                indexParachut = parachutPossition;
                col++;
                char symbol = row[parachutPossition];
                if (symbol != '-' & symbol != '>' & symbol != '<')
                {
                    CheckParachuteCondition(symbol, indexParachut, col);
                    return;
                }
            }
        }

        public static int FindWindMove(string row)
        {
            int rightMove = row.Count(x => x == '>');
            int leftMove = row.Count(x => x == '<');

            int move = rightMove - leftMove;
            return move;
        }

        public static void CheckParachuteCondition(char symbol, int row, int col)
        {
            if (symbol == '~')
            {
                Console.WriteLine("Drowned in the water like a cat!");
            }
            else if (symbol == '/' || symbol == '\\')
            {
                Console.WriteLine("Got smacked on the rock like a dog!");
            }
            else
            {
                Console.WriteLine("Landed on the ground like a boss!");
            }

            Console.WriteLine($"{col} {row}");
        }
    }
}