using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> myDictionary = new Dictionary<string, List<int>>();
            List<Messages> myList = new List<Messages>();
            string command = Console.ReadLine();
            while (command != "Statistics")
            {
                string[] splitter = command.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string commandArguments = splitter[0];

                if (commandArguments == "Add")
                {
                    if (myList.FirstOrDefault(x => x.Username == splitter[1]) == null)
                    {
                        myList.Add(new Messages((splitter[1]), int.Parse(splitter[2]), int.Parse(splitter[3])));
                    }
                }
                else if (commandArguments == "Message")
                {
                   
                    if (myList.FirstOrDefault(x => x.Username == splitter[1]) != null && myList.FirstOrDefault(x => x.Username == splitter[2]) != null)
                    {
                        string firstUser = String.Empty;
                        string secondUser = String.Empty;
                        myList.Where(x => x.Username == splitter[1]).Select(c =>
                        {
                            c.SentMessage += 1;
                            firstUser = c.Username;
                            return c;
                        }).ToList();
                        myList.Where(x => x.Username == splitter[2]).Select(c =>
                        {
                            c.ReceivedMessage += 1;
                            secondUser = c.Username;
                            return c;
                        }).ToList();
                        if (myList.Where(x => x.Username == splitter[1]).Any(x => x.SentMessage + x.ReceivedMessage >= capacity))
                        {
                            myList.RemoveAll(x => x.Username == splitter[1]);
                            Console.WriteLine($"{firstUser} reached the capacity!");
                        }

                        if (myList.Where(x => x.Username == splitter[2]).Any(x => x.ReceivedMessage + x.SentMessage >= capacity))
                        {
                            myList.RemoveAll(x => x.Username == splitter[2]);
                            Console.WriteLine($"{secondUser} reached the capacity!");
                        }

                    }
                }
                else if (commandArguments == "Empty")
                {
                    if (splitter[1] == "All")
                    {
                        myList.Clear();
                    }
                    else if (myList.FirstOrDefault(x => x.Username == splitter[1]) != null)
                    {
                        myList.RemoveAll(x => x.Username == splitter[1]);
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {myList.Count}");
            foreach (var kvp in myList)
            {
                int result = 0;
                foreach (var test in myList)
                {
                    if (test.Username == kvp.Username)
                    {
                        result = kvp.SentMessage + kvp.ReceivedMessage;
                    }
                }
                Console.WriteLine($"{kvp.Username} - {result}");
            }
        }


    }

    public class Messages
    {
        public string Username { get; set; }
        public int SentMessage { get; set; }
        public int ReceivedMessage { get; set; }

        public Messages(string username, int sentMessage, int receivedMessage)
        {
            this.Username = username;
            this.SentMessage = sentMessage;
            this.ReceivedMessage = receivedMessage;
        }
    }
}

