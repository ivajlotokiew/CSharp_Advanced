using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace _02.Array_Slider
{
    public class StartUp
    {
        private static List<BigInteger> list = new List<BigInteger>();
        private static int currentIndex = 0;

        public static void Main()
        {
            var data = Console.ReadLine().Split(new[] { ' ', '\t', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            list = new List<BigInteger>(data.Select(BigInteger.Parse));

            while (true)
            {
                var dataLine = Console.ReadLine().Split();

                if (dataLine[0] == "stop")
                {
                    PrintResult();
                    return;
                }

                var offset = int.Parse(dataLine[0]);
                var command = dataLine[1];
                var opperand = int.Parse(dataLine[2]);

                switch (command)
                {
                    case "*":
                        TakeCurrentIndex(offset, opperand);
                        list[currentIndex] = list[currentIndex] * opperand;

                        break;
                    case "/":
                        TakeCurrentIndex(offset, opperand);
                        list[currentIndex] = list[currentIndex] / opperand;

                        break;
                    case "-":
                        TakeCurrentIndex(offset, opperand);
                        list[currentIndex] = list[currentIndex] - opperand;

                        if (list[currentIndex] <= 0)
                        {
                            list[currentIndex] = 0;
                        }

                        break;

                    case "+":
                        TakeCurrentIndex(offset, opperand);
                        list[currentIndex] = list[currentIndex] + opperand;

                        break;
                    case "&":
                        TakeCurrentIndex(offset, opperand);
                        list[currentIndex] = list[currentIndex] & opperand;

                        break;
                    case "^":
                        TakeCurrentIndex(offset, opperand);
                        list[currentIndex] = list[currentIndex] ^ opperand;

                        break;
                    case "|":
                        TakeCurrentIndex(offset, opperand);
                        list[currentIndex] = list[currentIndex] | opperand;

                        break;
                    default:
                        throw new ArgumentException();
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }

        private static void TakeCurrentIndex(int offset, int action)
        {
            if (offset < 0)
            {
                var nextIndex = Math.Abs(offset) % list.Count;
                currentIndex -= nextIndex;

                if (currentIndex < 0)
                {
                    currentIndex = list.Count + currentIndex;
                }
            }
            else
            {
                var nextIndex = offset % list.Count;
                currentIndex += nextIndex;

                if (currentIndex >= list.Count)
                {
                    currentIndex -= list.Count;
                }
            }
        }
    }
}