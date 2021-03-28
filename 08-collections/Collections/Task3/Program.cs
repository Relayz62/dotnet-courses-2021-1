using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"Hello, guys! How are you, guys? Cool? Cool! Guys!";
            Dictionary<string, int> dict = CountWords(text);

            Func<KeyValuePair<string, int>, int> orders = (pair) => pair.Value;

            foreach (KeyValuePair<string, int> pair in dict.OrderByDescending(orders))
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }

        }


        private static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            string[] wordArray = Regex.Split(text, @"\W").Where(word => !string.IsNullOrWhiteSpace(word)).ToArray();

            foreach (string word in wordArray)
            {
                if (dictionary.ContainsKey(word))
                    dictionary[word]++;
                else
                {
                    dictionary[word] = 1;
                }
            }


            return dictionary;
        }
    }
}
