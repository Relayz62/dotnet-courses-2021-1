using System;

namespace Task4
{
    class Program
    {
        //Определить сумму элементов двумерного массива, стоящих на чётных позициях.
        //NOTE: элемент двумерного массива считается стоящим на чётной позиции, 
        //если сумма номеров его позиций по обеим размерностям является чётным числом (например, [1,1] – чётная позиция, а [1,2] - нет).
        static void Main(string[] args)
        {
            int[,] mass = new int[3, 3];
            Random rnd = new Random();
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = rnd.Next(-10, 10);
                }
            }
            PrintArray(mass);
            Console.WriteLine(GetSumOfEvenPositionsElements(mass));
            Console.ReadKey();
        }
        #region GetSumOfEvenPositionsElements
        private static int GetSumOfEvenPositionsElements(int[,] mass)
        {
            int sum=0;
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0) sum += mass[i, j];
                }
            }
            return sum;
        }

        #endregion

        #region PrintArray
        private static void PrintArray(int[,] mass)
        {
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    Console.Write("{0,3}", mass[i, j]);
                }
                Console.WriteLine();
            }

        }
        #endregion
    }
}

       // 8 -9  1
       //-9  8  0
       // 3 -9 -6
       // 14


