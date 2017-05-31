using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Problem_3___Cubic_s_Messages
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string firstWord = String.Empty;
            string secondWord = String.Empty;

            while (input != "Over!")
            {
                string text = input;
                input = Console.ReadLine();

                int lengthValidMessage = int.Parse(input);
                Regex regex = new Regex(@"^([0-9]+)([A-Za-z]{" + lengthValidMessage + "})([^A-Za-z]*)$");

                Match match = regex.Match(text);
                if (match.Length > 0)
                {
                    string word = match.Groups[2].Value;
                    string startIndexes = match.Groups[1].Value;
                    string endIndexes = match.Groups[3].Value;
                    for (int i = 0; i < startIndexes.Length; i++)
                    {
                        if (int.Parse(startIndexes[i].ToString()) >= word.Length)
                        {
                            firstWord += " ";
                        }
                        else
                        {
                            firstWord += word[int.Parse(startIndexes[i].ToString())];
                        }
                    }

                    for (int i = 0; i < endIndexes.Length; i++)
                    {
                        if (!char.IsDigit(endIndexes[i]))
                        {
                            break;
                        }
                        else
                        {
                            if (int.Parse(endIndexes[i].ToString()) >= word.Length)
                            {
                                secondWord += " ";
                            }
                            else
                            {
                                secondWord += word[int.Parse(endIndexes[i].ToString())];
                            }
                        }
                    }

                    Console.WriteLine($"{word} == {firstWord}{secondWord}");
                    firstWord = String.Empty;
                    secondWord = String.Empty;

                }

                input = Console.ReadLine();
            }
        }
    }
}