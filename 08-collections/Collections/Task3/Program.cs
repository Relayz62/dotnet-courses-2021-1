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
            string text = @"The little dragon lived by the sea. The sea is big, the dragon is small.";
            Dictionary<string, int> dict = CountWords(text);
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            
        }


        private static Dictionary<string,int> CountWords(string text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            text = text.ToUpper();
            string[] wordArray = text.Split(new char[] { ' ', ',', '.', ':', ';', '-', '?', '!', '\'','"',']','[' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string world in wordArray)
            {
                if (dictionary.ContainsKey(world))
                    dictionary[world]++;
                else
                {
                    dictionary[world] = 1;
                }
            }
            return dictionary;
        }
    }
}
