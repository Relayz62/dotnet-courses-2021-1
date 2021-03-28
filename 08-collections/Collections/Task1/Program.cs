using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            LinkedList<int> linkedList = new LinkedList<int>(Enumerable.Range(1, N));
            List<int> list = new List<int>(Enumerable.Range(1, 10));
            PrintCollection(linkedList);
            RemoveEachSecondItem(linkedList);

        }


        private static void RemoveEachSecondItem(ICollection<int> collection)
        {
            while(collection.Count !=1)
            {
                for (int i = 1; i <= collection.Count; i+=2)
                {
                    if (i >= collection.Count)
                        i = 0;
                    collection.Remove(collection.ElementAt(i--));
                }
                Console.WriteLine("//////////////////");
                PrintCollection(collection);
            }
        }

        private static void PrintCollection(ICollection<int> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
