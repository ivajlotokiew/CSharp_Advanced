namespace Problem_10.Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicatesParty
    {
        public static void Main()
        {
            List<string> nameList = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();

            var currentNameList = new List<string>(nameList);

            while (input != "Party!")
            {
                string[] commands = input.Split();

                string command = commands[0];
                string condition = commands[1];
                string data = commands[2];

                foreach (var name in nameList)
                {
                    switch (condition)
                    {
                        case "StartsWith":
                            bool resultStartWithStr = ActionWithStrings
                                (x => x == name.Substring(0, data.Length), data);

                            if (resultStartWithStr)
                            {
                                CheckCommandMethod(currentNameList, name, command);
                            }

                            break;

                        case "EndsWith":
                            bool resultEndWithStr = ActionWithStrings
                                (x => x == name.Substring(name.Length - x.Length), data);
                            if (resultEndWithStr)
                            {
                                CheckCommandMethod(currentNameList, name, command);
                            }

                            break;

                        case "Length":
                            bool restulStringLength = ActionWithStrings
                                (x => x == name.Length.ToString(), data);
                            if (restulStringLength)
                            {
                                CheckCommandMethod(currentNameList, name, command);
                            }

                            break;

                        default:
                            break;
                    }
                }

                nameList = new List<string>(currentNameList);

                input = Console.ReadLine();
            }

            Console.WriteLine($"{string.Join(", ", nameList)}" + " are going to the party!");
        }

        public static bool ActionWithStrings
            (Predicate<string> predicate, string data)
        {
            bool isResult = predicate(data);

            return isResult;
        }

        public static void CheckCommandMethod(List<string> list, string name, string command)
        {
            if (command == "Remove")
            {
                list.Remove(name);
            }
            else
            {
                list.Add(name);
            }
        }
    }
}