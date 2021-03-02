using System;

namespace Task3
{
    class Program
    {
        //Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве.
        static void Main(string[] args)
        {
            int[] mass = new int[5];
            Random rnd = new Random();
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = rnd.Next(-10, 10);
                Console.Write(mass[i] + " ");
            }
            Console.WriteLine("Сумма: " + GetSumOfNonNegativeElements(mass));

        }
        
        private static int GetSumOfNonNegativeElements(int[] mass)
        {
            int sum=0;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] >= 0) sum += mass[i];
            }
            return sum;
        }
    }
}
