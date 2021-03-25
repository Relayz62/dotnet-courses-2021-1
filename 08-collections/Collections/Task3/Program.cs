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
            string text = @"Hello, guys! How are you, guys? Cool? Cool!";
            Dictionary<string, int> dict = CountWords(text);

            foreach (KeyValuePair<string, int> pair in dict)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }

        }


        private static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string[] wordArray = Regex.Split(text, @"\W", RegexOptions.IgnoreCase).Where(word => !string.IsNullOrWhiteSpace(word)).ToArray();

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
