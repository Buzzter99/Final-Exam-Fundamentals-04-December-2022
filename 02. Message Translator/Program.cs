using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]");
            List<int> charSymbols = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                string currentInput = Console.ReadLine();
                Match match = regex.Match(currentInput);
                if (match.Success)
                {
                    //Console.WriteLine($"{match.Groups[1].Value}:");
                    string substring = match.Groups[2].Value;
                    foreach (var test in substring)
                    {
                        charSymbols.Add((int)test);
                    }

                    Console.WriteLine($"{match.Groups[1].Value}: {string.Join(" ",charSymbols)}");

                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
                charSymbols.Clear();
            }
        }
    }
}
