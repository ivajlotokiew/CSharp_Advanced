using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Command_Interpreter
{
    public class StartUp
    {
        private static List<string> list = new List<string>();

        public static void Main()
        {
            list = new List<string>(Console.ReadLine().Split());

            while (true)
            {
                string[] dataRow = Console.ReadLine().Split();
                var command = dataRow[0];

                switch (command)
                {
                    case "reverse":
                        int from = int.Parse(dataRow[2]);
                        int count = int.Parse(dataRow[4]);
                        if (!CheckForValidParamteres(from, count))
                        {
                            break;
                        }

                        ReverseExecute(from, count);
                        break;
                    case "sort":
                        int start = int.Parse(dataRow[2]);
                        int countElements = int.Parse(dataRow[4]);
                        if (!CheckForValidParamteres(start, countElements))
                        {
                            break;
                        }

                        SortingExecute(start, countElements);
                        break;
                    case "rollLeft":
                        int countShifts = int.Parse(dataRow[1]);
                        if (countShifts < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        LeftShiftsExecute(countShifts);
                        break;
                    case "rollRight":
                        int rightShifts = int.Parse(dataRow[1]);
                        if (rightShifts < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        RightShiftsExecute(rightShifts);
                        break;
                    case "end":
                        PrintExecute();
                        return;
                    default:
                        throw new ArgumentException("No such command");
                }
            }
        }

        private static bool CheckForValidParamteres(int from, int count)
        {
            if (from < 0 || from >= list.Count || count < 0 || from + count > list.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return false;
            }

            return true;
        }

        private static void PrintExecute()
        {
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }

        private static void RightShiftsExecute(int rightShifts)
        {
            var shifts = rightShifts % list.Count;

            var secondPart = list.Take(list.Count - shifts);
            var firstPart = list.Skip(secondPart.Count()).Take(list.Count - secondPart.Count());

            list = new List<string>(firstPart);
            list.AddRange(secondPart);
        }

        private static void LeftShiftsExecute(int countShifts)
        {
            var shifts = countShifts % list.Count;

            var secondPart = list.Take(shifts);
            var firstPart = list.Skip(secondPart.Count()).Take(list.Count - secondPart.Count());

            list = new List<string>(firstPart);
            list.AddRange(secondPart);
        }

        private static void SortingExecute(int start, int countElements)
        {
            var result = list.Skip(start).Take(countElements).OrderBy(x => x).ToList();

            for (int i = 0; i < result.Count(); i++)
            {
                list[start + i] = result[i];
            }
        }

        private static void ReverseExecute(int from, int count)
        {
            var result = list.Skip(from).Take(count).Reverse().ToList();

            for (int i = 0; i < result.Count(); i++)
            {
                list[from + i] = result[i];
            }
        }
    }
}