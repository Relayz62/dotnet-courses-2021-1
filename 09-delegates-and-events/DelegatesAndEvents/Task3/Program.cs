using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            SortModule sortModule = new SortModule();
            Func<string, string, int> stringComparer = CompareStrings;
            string[] array = { "Я", "Пошёл", "Гулять", "Яовсем", "Совсем", "Один", "Аовсем", "Потом", "Бовсем" };
            string[] array2 = { "Я", "Пошёл", "Гулять", "Яовсем", "Совсем", "Один", "Аовсем", "Потом", "Бовсем" };
            sortModule.SortFinished += SortModule_SortFinished;
            Thread thread = sortModule.SortAsync(array2, stringComparer);
            Thread thread2 = sortModule.SortAsync(array, stringComparer);
            thread.Join();
            thread2.Join();
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static void SortModule_SortFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Сортировка закончена");

        }

        public static int CompareStrings(string first, string second)
        {
            int compareResultLenght = first.Length.CompareTo(second.Length);
            int compareResult = first.CompareTo(second);
            return compareResultLenght == 0 ? compareResult : compareResultLenght;
        }




    }
}
