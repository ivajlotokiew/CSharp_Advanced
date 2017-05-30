using System;
using System.Collections.Generic;

namespace Problem_7.Fix_emails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();
            string input = String.Empty;
            int counter = 0;
            string name = string.Empty;
            string email = string.Empty;

            while ((input = Console.ReadLine()) != "stop")
            {
                if (counter % 2 == 0)
                {
                    name = input;

                    if (!emails.ContainsKey(name))
                    {
                        emails[name] = string.Empty;
                    }
                }
                else
                {
                    email = input;
                    emails[name] = email;
                }

                counter++;
            }

            foreach (var i in emails)
            {
                string spamMails = i.Value.Remove(0, i.Value.Length - 2);

                if (spamMails == "us" || spamMails == "Us" || spamMails == "US" || spamMails == "uS"
                    || spamMails == "uk" || spamMails == "Uk" || spamMails == "UK" || spamMails == "uK")
                {
                    continue;
                }

                Console.WriteLine($"{i.Key} -> {i.Value}");
            }
        }
    }
}