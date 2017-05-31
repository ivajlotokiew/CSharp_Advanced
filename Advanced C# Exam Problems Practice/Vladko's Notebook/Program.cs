using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.Problem
{
    public class Player
    {
        public Player()
        {
            this.isAge = false;
            this.isName = false;
            this.Opponents = new List<string>();
            this.Rank = new List<string>();
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public List<string> Opponents { get; set; }

        public List<string> Rank { get; set; }

        public bool isAge { get; set; }

        public bool isName { get; set; }
    }

    public class VladkosNotebook
    {
        public static void Main()
        {
            var playersInfo = new Dictionary<string, Player>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] info = input.Split('|');

                string color = info[0];
                string action = info[1];
                string actionData = info[2];

                if (!playersInfo.ContainsKey(color))
                {
                    playersInfo[color] = new Player();
                }

                switch (action)
                {
                    case "age":
                        playersInfo[color].Age = int.Parse(actionData);
                        playersInfo[color].isAge = true;
                        break;
                    case "loss":
                        playersInfo[color].Opponents.Add(actionData);
                        playersInfo[color].Rank.Add("loss");
                        break;
                    case "win":
                        playersInfo[color].Opponents.Add(actionData);
                        playersInfo[color].Rank.Add("win");
                        break;
                    default:
                        playersInfo[color].Name = actionData;
                        playersInfo[color].isName = true;
                        break;
                }

                input = Console.ReadLine();
            }

            var matches = playersInfo.Values.Where(st => st.isAge && st.isName);

            if (!matches.Any())
            {
                Console.WriteLine("No data recovered.");
            }
            else
            {
                foreach (KeyValuePair<string, Player> pair in playersInfo.OrderBy(st => st.Key))
                {
                    if (!(pair.Value.Age == 0 || pair.Value.Name == null))
                    {
                        StringBuilder output = new StringBuilder();

                        output.AppendLine($"Color: {pair.Key}");
                        output.AppendLine($"-age: {pair.Value.Age}");
                        output.AppendLine($"-name: {pair.Value.Name}");

                        if (pair.Value.Opponents.Count == 0)
                        {
                            output.AppendLine("-opponents: (empty)");
                        }
                        else
                        {
                            var orderedOpponents =
                                pair.Value
                                    .Opponents
                                    .OrderBy(name => name, StringComparer.Ordinal);
                            output.AppendLine($"-opponents: {string.Join(", ", orderedOpponents)}");
                        }

                        int wins = pair.Value.Rank.Count(win => win == "win") + 1;
                        int losses = pair.Value.Rank.Count(loss => loss == "loss") + 1;
                        decimal rank = (decimal)wins / losses;

                        output.AppendLine($"-rank: {rank:F2}");

                        Console.Write(output);
                        output.Clear();
                    }
                }
            }
        }
    }
}