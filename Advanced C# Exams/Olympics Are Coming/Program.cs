using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


class OlympicsAreComing
{
    static void Main()
    {
        var dataDictionary = new Dictionary<string, List<string>>();
        string inputData = Console.ReadLine();
        // Ivan ivanov | Bulgaria
        while (inputData != "report")
        {
            string[] dataBuffer = inputData.Split('|');
            string country = dataBuffer[1].ToString();
            country = Regex.Replace(country.Trim(), @"\s{2,}", " ");
            string player = dataBuffer[0].ToString();
            player = Regex.Replace(player.Trim(), @"\s{2,}", " ");

            if (!(dataDictionary.ContainsKey(country)))
            {
                dataDictionary.Add(country, new List<string>());
                dataDictionary[country].Add(player);
            }
            else
            {
                dataDictionary[country].Add(player);
            }

            inputData = Console.ReadLine();
        }
        var result = dataDictionary.OrderByDescending(x => x.Value.Count);
        // Bulgaria (2 participants): 3 wins

        foreach (var item in result)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins",
               item.Key, item.Value.Distinct().Count(), item.Value.Count);
        }

    }
}