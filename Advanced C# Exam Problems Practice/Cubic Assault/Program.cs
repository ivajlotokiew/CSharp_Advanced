using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04___Cubic_Assault
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var mainDictionary = new SortedDictionary<string, SortedDictionary<string, long>>();

            while (input != "Count em all")
            {
                string[] inputArray = Regex.Split(input, @"\s*->\s*");
                string regionName = inputArray[0];
                string colorType = inputArray[1];
                long countOnType = long.Parse(inputArray[2]);

                if (!mainDictionary.ContainsKey(regionName))
                {
                    mainDictionary.Add(regionName, new SortedDictionary<string, long>());
                    mainDictionary[regionName]["Black"] = 0;
                    mainDictionary[regionName]["Green"] = 0;
                    mainDictionary[regionName]["Red"] = 0;
                }
                if (mainDictionary[regionName][colorType] == 0)
                {
                    mainDictionary[regionName][colorType] = countOnType;
                }
                else
                {
                    mainDictionary[regionName][colorType] += countOnType;
                }

                long count = mainDictionary[regionName][colorType];
                CheckForTypeChanges(mainDictionary, regionName, colorType, count);

                input = Console.ReadLine();
            }

            var regions = mainDictionary
                    .OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length);

            foreach (var region in regions)
            {
                Console.WriteLine($"{region.Key}");
                foreach (var item in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {item.Key} : {item.Value}");
                }
            }
        }

        private static void CheckForTypeChanges(
            SortedDictionary<string, SortedDictionary<string, long>> mainDictionary,
            string regionName, string colorType, long count)
        {

            switch (colorType)
            {
                case "Green":
                    if (count >= 1000000)
                    {
                        mainDictionary[regionName]["Green"] = count % 1000000;
                        mainDictionary[regionName]["Red"] += (count - (count % 1000000)) / 1000000;
                        if (mainDictionary[regionName]["Red"] >= 1000000)
                        {
                            long currentNumb = mainDictionary[regionName]["Red"];
                            mainDictionary[regionName]["Red"] = currentNumb % 1000000;
                            mainDictionary[regionName]["Black"] +=
                                (currentNumb - (currentNumb % 1000000)) / 1000000;
                        }
                    }
                    break;
                case "Red":
                    if (count >= 1000000)
                    {
                        mainDictionary[regionName]["Red"] = count % 1000000;
                        mainDictionary[regionName]["Black"] += (count - (count % 1000000)) / 1000000;
                    }
                    break;
            }
        }
    }
}