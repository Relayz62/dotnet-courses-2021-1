using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, int> stringComparer = CompareStrings;
            string[] array = { "Я", "Пошёл", "Гулять", "Яовсем","Совсем", "Один", "Аовсем", "Потом", "Бовсем" };
            Sort(array, stringComparer);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public static void Sort(string[] array, Func<string,string,int> stringComparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    ref string first = ref array[j];
                    ref string second = ref array[j+1];
                    if (stringComparer(first,second) > 0)
                    {
                        (first, second) = (second, first);
                    }
                }
            }
        }

        public static int CompareStrings(string first, string second)
        {
            int compareResultLenght = first.Length.CompareTo(second.Length);
            int compareResult = first.CompareTo(second);
            return compareResultLenght == 0 ? compareResult : compareResultLenght;
        }
    }
}
