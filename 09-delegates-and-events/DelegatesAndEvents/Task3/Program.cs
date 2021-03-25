﻿using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        public delegate int StringComparer(string first, string second);
        static void Main(string[] args)
        {
            SortModule sortModule = new SortModule();
            string[] array = { "Как дела?", "Как дела?" };
            string[] array2 = { "Новый?", "Год?" };
            Sort(array, CompareStrings);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            sortModule.CreateThreadForSorting(array2, CompareStrings);
            sortModule.SortingFinished += (object sender, EventArgs args) => Console.WriteLine("Sorting Finished");
            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            
        }

        public static void Sort(string[] array, StringComparer stringComparer)
        {
            stringComparer += CompareStrings;
            for (int i = 0; i < array.Length - 1; i++)
            {
                switch (stringComparer(array[i], array[i + 1]))
                {
                    case 0:
                        Array.Sort<string>(array, (first, second) => string.Compare(first, second));
                        break;
                    case 1:
                        string temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        break;
                }
            }           
            stringComparer -= CompareStrings;
        }

        public static int CompareStrings(string first, string second)
        {
            if (first.Length > second.Length) return -1;
            if (first.Length < second.Length) return 1;
            return 0;
        }
    }
}
