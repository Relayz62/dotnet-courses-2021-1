using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] mass1 = new int[5] { 1, 2, 3, 4, 5 };
            List<int> list = new List<int>() { 1, 2, 3 };
            DynamicArray<int> test1 = new DynamicArray<int>(list);
            test1.PrintDynamicArray();
            test1.Add(2);
            test1.PrintDynamicArray();
            test1.AddRange(mass1);
            test1.PrintDynamicArray();
            test1.Insert(0, 22);
            test1.PrintDynamicArray();
            test1.Insert(4, 22);
            test1.PrintDynamicArray();
            test1.Remove(22);
            test1.PrintDynamicArray();           
            test1.Remove(22345);

        }
    }
}
