using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();
            string input = Console.ReadLine();
            
            while (input != "Abracadabra")
            {
                string[] splitter = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = splitter[0];
                if (command == "Abjuration")
                {
                    spell = spell.ToUpper();
                    Console.WriteLine(spell);
                } else if (command == "Necromancy")
                {
                    spell = spell.ToLower();
                    Console.WriteLine(spell);
                } else if (command == "Illusion")
                {
                    int index = int.Parse(splitter[1]);
                    string letter = splitter[2];
                    if (index >= 0 && index < spell.Length)
                    {
                        string symbol = spell.Substring(index, splitter[1].Length);
                        spell = spell.Remove(index, symbol.Length);
                        spell = spell.Insert(index, splitter[2]);
                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                } else if (command == "Divination")
                {
                    if (spell.Contains(splitter[1]))
                    {
                        spell = spell.Replace(splitter[1], splitter[2]);
                        Console.WriteLine(spell);
                    }
                } else if (command == "Alteration")
                {
                    if (spell.Contains(splitter[1]))
                    {
                        spell = spell.Remove(spell.IndexOf(splitter[1]), splitter[1].Length);
                        Console.WriteLine(spell);
                    }
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }
            
                input = Console.ReadLine();
            }

        }
    }
}
