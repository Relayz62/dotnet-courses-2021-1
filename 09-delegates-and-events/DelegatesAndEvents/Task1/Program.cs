using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        public delegate int StringComparer(string first, string second);
        static void Main(string[] args)
        {
            StringComparer stringComparer = CompareStrings;
            string[] array = { "Я", "Пошёл", "Совсем", "Гулять", "Один", "Аовсем" };
            Sort(array, stringComparer);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public static void Sort(string[] array, StringComparer stringComparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                string word = array[i];
                int index = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (stringComparer(word, array[j]) > 0)
                    {
                        word = array[j];
                        index = j;
                    }
                }
                array[index] = array[i];
                array[i] = word;
            }
        }


        public static int CompareStrings(string first, string second)
        {
            return first.Length - second.Length;
        }
    }
}
