using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,,] mass = new int[5, 5, 5];

            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    for (int k = 0; k < mass.GetLength(2); k++)
                    {
                        mass[i, j, k] = rnd.Next(-10, 10);
                    }
                }
            }
            PrintArray(mass);
            ReplacePositiveElementsWithZero(mass);
            Console.WriteLine("/////////////Replace/////////////");
            PrintArray(mass);
        }

        private static void ReplacePositiveElementsWithZero(int[,,] mass)
        {
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    for (int k = 0; k < mass.GetLength(2); k++)
                    {
                        if (mass[i, j, k] > 0) mass[i, j, k] = 0;
                    }
                }
            }
        }

        private static void PrintArray(int[,,] mass)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        Console.Write("{0,3}", mass[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
