using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] mass = new int[5, 5, 5];

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    for (int k = 0; k < 5; k++)
                        mass[i, j, k] = i + j + k;
        }

        private static void ReplacePositiveElementsWithZero(int[,,] mass)
        {

        }
    }
}
