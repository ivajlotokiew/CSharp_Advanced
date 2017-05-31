using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Cubic_s_Rube
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long cubeSize = int.Parse(Console.ReadLine());
            long sizeCube = cubeSize * cubeSize * cubeSize;
            long notChangedCells = (long)sizeCube;
            string input = Console.ReadLine();
            long sum = 0;
            HashSet<string> checkCoordinates = new HashSet<string>();

            while (input != "Analyze")
            {
                long sizeHashset = checkCoordinates.Count;
                int indexCoord = input.LastIndexOf(" ");
                string onlyXYZ = input.Remove(indexCoord);
                string onlyParticle = input.Remove(0, indexCoord + 1);
                if (!onlyXYZ.Contains("-") && onlyParticle != "0")
                {
                    checkCoordinates.Add(onlyXYZ);

                    if (checkCoordinates.Count > sizeHashset)
                    {
                        long[] coordinates = input.Split().Select(long.Parse).ToArray();
                        long x = coordinates[0];
                        long y = coordinates[1];
                        long z = coordinates[2];
                        long particles = coordinates[3];

                        bool inRange = x <= cubeSize && y <= cubeSize && z <= cubeSize;
                        if (inRange)
                        {
                            sum += particles;
                            notChangedCells--;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{sum}");
            Console.WriteLine($"{notChangedCells}");
        }
    }
}