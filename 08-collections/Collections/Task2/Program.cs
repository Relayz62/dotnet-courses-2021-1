using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3, 4, 5, 6 });

            foreach (var item in dynamicArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
