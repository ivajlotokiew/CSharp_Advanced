using System;
using System.Collections.Generic;
using System.Linq;

namespace Champion_s_League
{
    class Program
    {
        static void Main()
        {
            var teams = new Dictionary<string, LinkedList<string>>();
            var teamWins = new Dictionary<string, int>();

            string[] data = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim()).ToArray();

            while (data[0] != "stop")
            {
                string team1 = data[0];
                string team2 = data[1];
                int winsTeam1 = 0;
                int winsTeam2 = 0;
                int[] resultFirstMatch = data[2].Split(':').Select(int.Parse).ToArray();
                int[] resultSecondMatch = data[3].Split(':').Select(int.Parse).ToArray();

                int scoreFirstMatchTeam1 = resultFirstMatch[0];
                int scoreFirstMatchTeam2 = resultFirstMatch[1];
                int scoreSecondMatchTeam1 = resultSecondMatch[1];
                int scoreSecondMatchTeam2 = resultSecondMatch[0];

                if (scoreFirstMatchTeam1 + scoreSecondMatchTeam1 > scoreFirstMatchTeam2 + scoreSecondMatchTeam2)
                {
                    if (!teams.ContainsKey(team1))
                    {
                        teams.Add(team1, new LinkedList<string>());
                        teamWins.Add(team1, 0);
                    }

                    teams[team1].AddLast(team2);
                    int wins = teamWins[team1] + 1;
                    teamWins[team1] = wins;

                    if (!teams.ContainsKey(team2))
                    {
                        teams.Add(team2, new LinkedList<string>());
                        teamWins.Add(team2, 0);
                    }

                    teams[team2].AddLast(team1);
                    int winsLosingTeam = teamWins[team2];
                    teamWins[team2] = winsLosingTeam;
                }
                else if (scoreFirstMatchTeam1 + scoreSecondMatchTeam1 < scoreFirstMatchTeam2 + scoreSecondMatchTeam2)
                {
                    if (!teams.ContainsKey(team2))
                    {
                        teams.Add(team2, new LinkedList<string>());
                        teamWins.Add(team2, 0);
                    }

                    teams[team2].AddLast(team1);
                    int wins = teamWins[team2] + 1;
                    teamWins[team2] = wins;

                    if (!teams.ContainsKey(team1))
                    {
                        teams.Add(team1, new LinkedList<string>());
                        teamWins.Add(team1, 0);
                    }

                    teams[team1].AddLast(team2);
                    int winsLosingTeam = teamWins[team1];
                    teamWins[team1] = winsLosingTeam;
                }
                else
                {
                    if (scoreFirstMatchTeam2 > scoreSecondMatchTeam1)
                    {
                        if (!teams.ContainsKey(team2))
                        {
                            teams.Add(team2, new LinkedList<string>());
                            teamWins.Add(team2, 0);
                        }

                        teams[team2].AddLast(team1);
                        int wins = teamWins[team2] + 1;
                        teamWins[team2] = wins;

                        if (!teams.ContainsKey(team1))
                        {
                            teams.Add(team1, new LinkedList<string>());
                            teamWins.Add(team1, 0);
                        }

                        teams[team1].AddLast(team2);
                        int winsLosingTeam = teamWins[team1];
                        teamWins[team1] = winsLosingTeam;
                    }
                    else
                    {
                        if (!teams.ContainsKey(team1))
                        {
                            teams.Add(team1, new LinkedList<string>());
                            teamWins.Add(team1, 0);
                        }

                        teams[team1].AddLast(team2);
                        int wins = teamWins[team1] + 1;
                        teamWins[team1] = wins;

                        if (!teams.ContainsKey(team2))
                        {
                            teams.Add(team2, new LinkedList<string>());
                            teamWins.Add(team2, 0);
                        }

                        teams[team2].AddLast(team1);
                        int winsLosingTeam = teamWins[team2];
                        teamWins[team2] = winsLosingTeam;
                    }
                }

                data = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim()).ToArray();
            }

            foreach (var kvPair in teamWins.OrderByDescending(e => e.Value).ThenBy(e => e.Key))
            {
                Console.WriteLine(kvPair.Key);
                Console.WriteLine("- Wins: " + kvPair.Value);
                Console.WriteLine("- Opponents: " + string.Join(", ", teams[kvPair.Key].OrderBy(a => a)));
            }
        }
    }
}