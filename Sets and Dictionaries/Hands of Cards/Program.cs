using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Problem_8.Hands_of_cards
{
    class HandsOfCards
    {
        static void Main(string[] args)
        {
            var playerData = new Dictionary<string, HashSet<string>>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "JOKER")
            {
                string[] data = input.Split(':');
                string namePlayer = data[0];
                string[] values = data[1].Split(new char[] { ',', ' ' }, StringSplitOptions.None);

                if (!playerData.ContainsKey(namePlayer))
                {
                    playerData.Add(namePlayer, new HashSet<string>());
                }

                for (int i = 0; i < values.Length; i++)
                {
                    playerData[namePlayer].Add(values[i]);
                }
            }

            foreach (var item in playerData)
            {
                int totalValueCard = executeTotalValue(item.Value);

                Console.WriteLine($"{item.Key}: {totalValueCard}");
            }
        }

        private static int executeTotalValue(HashSet<string> executeValue)
        {
            int sum = 0;

            foreach (var item in executeValue)
            {
                string card = item;

                if (card.Length == 2)
                {
                    char value = card[0];
                    char type = card[1];

                    var valueCard = 0;

                    if (char.IsDigit(value))
                    {
                        valueCard = int.Parse(value.ToString());
                    }
                    else if (value == 'J')
                    {
                        valueCard = 11;
                    }
                    else if (value == 'Q')
                    {
                        valueCard = 12;
                    }
                    else if (value == 'K')
                    {
                        valueCard = 13;
                    }
                    else
                    {
                        valueCard = 14;
                    }

                    var valueType = 0;

                    if (type == 'C')
                    {
                        valueType = 1;
                    }
                    else if (type == 'D')
                    {
                        valueType = 2;
                    }
                    else if (type == 'H')
                    {
                        valueType = 3;
                    }
                    else
                    {
                        valueType = 4;
                    }

                    var currentSum = valueCard * valueType;
                    sum += currentSum;
                }
                else if (card.Length == 3)
                {
                    char type = card[2];
                    var valueCard = 10;

                    var valueType = 0;

                    if (type == 'C')
                    {
                        valueType = 1;
                    }
                    else if (type == 'D')
                    {
                        valueType = 2;
                    }
                    else if (type == 'H')
                    {
                        valueType = 3;
                    }
                    else
                    {
                        valueType = 4;
                    }

                    var currentSum = valueCard * valueType;
                    sum += currentSum;
                }
            }

            return sum;
        }
    }
}